using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Messenger.Domain.Roles;

namespace Messenger.Domain.Chats
{
    public class Group : IGroup, IModerable, ISubscription
    {
        public ICreator Creator { get; }
        public int GroupId { get; } //immutable 

        public ReadOnlyCollection<IChatter> Chatters =>
            new ReadOnlyCollection<IChatter>(_chatters); //immutable collection

        public ReadOnlyCollection<IModerator> Moderators =>
            new ReadOnlyCollection<IModerator>(_moderators); //immutable collection

        private readonly IList<IChatter> _chatters;
        private readonly IList<IModerator> _moderators;

        private readonly IMessagesRepository _messagesRepository;
        private readonly IMessageIdGenerator _messageIdGenerator;

        public Group(ICreator creator, int groupId, IMessagesRepository messagesRepository,
            IMessageIdGenerator messageIdGenerator)
        {
            Creator = creator;
            GroupId = groupId;
            _chatters = new List<IChatter>();
            _moderators = new List<IModerator>();
            _messagesRepository = messagesRepository;
            _messageIdGenerator = messageIdGenerator;
            _chatters.Add(creator);
            _moderators.Add(creator);
        }

        public void AddModerator(IModerator moderator)
        {
            _chatters.Add(moderator);
            _moderators.Add(moderator);
        }

        public void RemoveModerator(IModerator moderator)
        {
            _chatters.Add(moderator);
            _moderators.Add(moderator);
        }

        public OperationStatus AddMessage(IChatter chatter, string textMessage)
        {
            var chatterIsInGroup = _chatters.FirstOrDefault(c => c.Equals(chatter));
            if (chatterIsInGroup == null)
            {
                return OperationStatus.NoSuchChatter;
            }

            var msgGlobalId = _messageIdGenerator.GetNextMessageId();
            var message = new Message(textMessage, msgGlobalId, chatter.UserId,
                _chatters.Select(s => s.UserId).ToList());
            return _messagesRepository.AddMessage(message, GroupId);
        }

        public OperationStatus DeleteMessage(IChatter role, int messageId)
        {
            return role switch
            {
                ICreator groupCreator => IsCreatorOfThisGroup(groupCreator)
                    ? TryDeleteMessage(messageId, groupCreator.UserId)
                    : OperationStatus.NotHaveCredentials,
                IModerator moderator => IsModeratorOfThisGroup(moderator)
                    ? TryDeleteMessageHighCredentials(messageId)
                    : OperationStatus.NoSuchModerator,
                { } chatter => IsChatterOfThisGroup(chatter)
                    ? TryDeleteMessageHighCredentials(messageId)
                    : OperationStatus.NoSuchChatter,
                _ => OperationStatus.NotHaveCredentials
            };
        }

        private bool IsCreatorOfThisGroup(ICreator groupCreator)
        {
            return groupCreator.Equals(Creator);
        }

        private bool IsChatterOfThisGroup(IChatter chatter)
        {
            return _chatters.FirstOrDefault(chatUser => chatUser.Equals(chatter)) != null;
        }

        private bool IsModeratorOfThisGroup(IModerator moderator)
        {
            return _moderators.FirstOrDefault(mod => mod.Equals(moderator)) != null;
        }

        public OperationStatus EditMessage(IChatter role, int messageId, string textForReplace)
        {
            return role switch
            {
                ICreator groupCreator => IsCreatorOfThisGroup(groupCreator)
                    ? TryEditMessage(messageId, textForReplace, groupCreator.UserId)
                    : OperationStatus.NotHaveCredentials,
                IModerator moderator => IsModeratorOfThisGroup(moderator)
                    ? TryEditMessage(messageId, textForReplace, moderator.UserId)
                    : OperationStatus.NoSuchModerator,
                { } chatter => IsChatterOfThisGroup(chatter)
                    ? TryEditMessage(messageId, textForReplace, chatter.UserId)
                    : OperationStatus.NoSuchChatter,
                _ => OperationStatus.NotHaveCredentials
            };
        }

        public void AddChatter(IChatter subscriber)
        {
            _chatters.Add(subscriber);
        }

        public void RemoveChatter(IChatter subscriber)
        {
            _chatters.Remove(subscriber);
        }

        private OperationStatus TryDeleteMessage(int messageId, int userId)
        {
            return _messagesRepository.DeleteMessage(messageId, userId, GroupId);
        }
        
        private OperationStatus TryDeleteMessageHighCredentials(int messageId)
        {
            return _messagesRepository.DeleteMessageNoUserIdCheck(messageId, GroupId);
        }

        private OperationStatus TryEditMessage(int messageId, string textMessage, int userId)
        {
            return _messagesRepository.EditMessage(messageId, textMessage, userId, GroupId);
        }
    }
}