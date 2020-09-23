using System;
using System.Collections.Generic;
using System.Linq;

namespace Messenger.Domain.Chats
{
    public class Group : IContatable, IModerable, ISubject
    {
        public ICreator Creator { get; }
        public IList<Chatter> Chatters { get; }
        public IList<Moderator> Moderators { get; }
        public int GroupId { get; }
        
        private IList<GroupMessage>
            messages; //TODO IList -> replace to repository. Messages can be heavy. Navigating can be long   

        public Group(ICreator creator, int groupId)
        {
            Creator = creator;
            GroupId = groupId;
            Chatters = new List<Chatter>();
            Moderators = new List<Moderator>();
        }

        public void AddModerator(Moderator moderator)
        {
            Chatters.Add(moderator);
            Moderators.Add(moderator);
        }

        public void RemoveModerator(Moderator moderator)
        {
            Chatters.Add(moderator);
            Moderators.Add(moderator);
        }
        
        public OperationStatus AddMessage(IChatRole chatter, string textMessage)
        {
            var chatterIsInGroup = Chatters.FirstOrDefault(c => c.Equals(chatter));
            if (chatterIsInGroup == null)
            {
                return OperationStatus.NoSuchChatter;
            }
            else
            {
                //TODO generate global id from repo
                var msgGlobalId = 42;
                var message = new Message(textMessage, msgGlobalId, chatter.UserId);
                messages.Add(new GroupMessage(chatter, message));
                return OperationStatus.Success;
            }
        }

        public OperationStatus DeleteMessage(IChatRole role, int messageId)
        {
            switch (role) //pattern matching 
            {
                case GroupCreator groupCreator:
                    if (groupCreator.Equals(Creator))
                    {
                        return TryDeleteMessage(msg=> msg.Message.MessageId == messageId);
                    }
                    else
                    {
                        return OperationStatus.NotHaveCredentials;
                    }
                case Moderator moderator:
                    var existingModerator = Moderators.FirstOrDefault(mod => mod.Equals(moderator));
                    if (existingModerator != null)
                    {
                        return TryDeleteMessage(msg=> msg.Message.MessageId == messageId);
                    }
                    else
                    {
                        return OperationStatus.NoSuchModerator;
                    }
                case Chatter chatter:
                    var existingChatter = Chatters.FirstOrDefault(chatUser => chatUser.Equals(chatter));
                    if (existingChatter != null)
                    {
                        return TryDeleteMessage(msg=> msg.Message.MessageId == messageId && chatter.UserId == msg.Sender.UserId);
                    }
                    else
                    {
                        return OperationStatus.NoSuchModerator;
                    }

                default: return OperationStatus.NotHaveCredentials;
            }
        }

        public OperationStatus EditMessage(IChatRole role, int messageId, string textForReplace)
        {
            switch (role) //pattern matching 
            {
                case GroupCreator groupCreator:
                    if (groupCreator.Equals(Creator))
                    {
                        return TryEditMessage(msg=> msg.Message.MessageId == messageId, textForReplace);
                    }
                    else
                    {
                        return OperationStatus.NotHaveCredentials;
                    }
                case Moderator moderator:
                    var existingModerator = Moderators.FirstOrDefault(mod => mod.Equals(moderator));
                    if (existingModerator != null)
                    {
                        return TryEditMessage(msg=> msg.Message.MessageId == messageId, textForReplace);
                    }
                    else
                    {
                        return OperationStatus.NoSuchModerator;
                    }
                case Chatter chatter:
                    var existingChatter = Chatters.FirstOrDefault(chatUser => chatUser.Equals(chatter));
                    if (existingChatter != null)
                    {
                        return TryEditMessage(msg => messageId == msg.Message.MessageId && chatter.UserId == msg.Sender.UserId, textForReplace);
                    }
                    else
                    {
                        return OperationStatus.NoSuchModerator;
                    }

                default: return OperationStatus.NotHaveCredentials;
            }
        }
        
        public void AddChatter(Chatter subscriber)
        {
            Chatters.Add(subscriber);
        }

        public void RemoveChatter(Chatter subscriber)
        {
            Chatters.Remove(subscriber);
        }

        public void Notify(Message message)
        {
            foreach (var chatter in Chatters)
            {
                chatter.Update(message);
            }
        }
        private OperationStatus TryDeleteMessage(Func<GroupMessage, bool> predicate)
        {
            var messageForDelete = messages.FirstOrDefault(predicate);
            if (messageForDelete != null)
            {
                messages.Remove(messageForDelete);
                return OperationStatus.Success;
            }
            else
            {
                return OperationStatus.NoSuchMessage;
            }
        }
        
        private OperationStatus TryEditMessage(Func<GroupMessage, bool> predicate, string textMessage)
        {
            var existingMessageForEdit = messages.FirstOrDefault(predicate);
            if (existingMessageForEdit != null)
            {
                existingMessageForEdit.Message.Text = textMessage;
                return OperationStatus.Success;
            }
            else
            {
                return OperationStatus.NoSuchMessage;
            }
        }

    }
}