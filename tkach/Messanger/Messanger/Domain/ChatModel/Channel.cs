using System;
using System.Collections.Generic;
using Messanger.Domain.MessageModel;

namespace Messanger.Domain.ChatModel
{
    public class Channel : ChatModel.Chat, IGroupChat
    {
        public Channel(string name, List<Guid> memberCollection, Guid ownerId)
        : base(name, memberCollection)
        {
            this._ownerId = ownerId;
            this._adminIdCollection = new List<Guid>();
            this._adminIdCollection.Add(this._ownerId);
        }
        
        public override void SendMessage(IMessage message)
        {
            try
            {
                if (((IGroupChat) this).CheckIfUserCanSendMessage(message.SenderUserId))
                {
                    base.SendMessage(message);
                }
                else
                {
                    throw new Exception("You have no rights to send messages in this channel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public override void EditMessage(Guid oldmessageId, object content)
        {
            try
            {
                IMessage oldMessage = base.GetMessageById(oldmessageId);
                if (((IGroupChat) this).CheckIfUserCanEditMessage(oldMessage.SenderUserId))
                {
                    base.EditMessage(oldmessageId, content);
                }
                else
                {
                    throw new Exception("You have no rights to edit messages in this channel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public override void DeleteMessage(Guid messageId)
        {
            IMessage message = base.GetMessageById(messageId);
            try
            {
                if (((IGroupChat) this).CheckIfUserCanDeleteMessage(message.SenderUserId))
                {
                    base.DeleteMessage(messageId);
                }
                else
                {
                    throw new Exception("You have no rights to delete messages in this channel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private Guid _ownerId;
        public Guid OwnerId
        {
            get { return this._ownerId; }
        }

        private List<Guid> _adminIdCollection;
        public IEnumerable<Guid> AdminIdCollection
        {
            get { return this._adminIdCollection; }
        }
        bool IGroupChat.CheckIfUserCanEditMemberIdCollection(Guid userId)
        {
            return userId == this._ownerId ? true : false;
        }

        public void AddUser(Guid userId)
        {
            try
            {
                if (((IGroupChat) this).CheckIfUserCanEditMemberIdCollection(userId))
                {
                    this._memberCollection.Add(userId);
                }
                else
                {
                    throw new Exception("You have no rights to add users in this channel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void RemoveUser(Guid userId)
        {
            try
            {
                if (((IGroupChat) this).CheckIfUserCanEditMemberIdCollection(userId))
                {
                    if(this._memberCollection.Find(member => member == userId).Equals(null))
                        throw new Exception("there is no such user in this channel!");
                    this._memberCollection.Remove(userId);
                }
                else
                {
                    throw new Exception("You have no rights to remove users in this channel");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        bool IGroupChat.CheckIfUserCanSendMessage(Guid user)
        {
            return user == this._ownerId ? true : false;
        }

        bool IGroupChat.CheckIfUserCanEditMessage(Guid user)
        {
            return user == this._ownerId ? true : false;
        }

        bool IGroupChat.CheckIfUserCanDeleteMessage(Guid user)
        {
            return user == this._ownerId ? true : false;
        }
    }
}