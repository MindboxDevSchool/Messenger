using System;
using System.Collections.Generic;
using Messanger.Domain.MessageModel;

namespace Messanger.Domain.ChatModel
{
    public class Group : ChatModel.Chat ,IGroupChat
    {
        public Group(string name, List<Guid> memberCollection, Guid ownerId, List<Guid> adminIdCollection)
            : base(name, memberCollection)
        {
            this._ownerId = ownerId;
            this._adminIdCollection = new List<Guid>(adminIdCollection);
            this._adminIdCollection.Add(this._ownerId);
        }
        
        private Guid _ownerId;
        public Guid OwnerId
        {
            get { return this._ownerId; }
        }

        private List<Guid> _adminIdCollection;
        public IEnumerable<Guid> AdminIdCollection
        {
            get { return new List<Guid>(this._adminIdCollection); }
        }
        public bool CheckIfUserCanEditMemberIdCollection(Guid userId)
        {
            return this._adminIdCollection.Contains(userId);
        }

        void IGroupChat.AddUser(Guid userId)
        {
            try
            {
                if (((IGroupChat) this).CheckIfUserCanEditMemberIdCollection(userId))
                {
                    this._memberCollection.Add(userId);
                }
                else
                {
                    throw new Exception("You have no rights to add users in this group");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        void IGroupChat.RemoveUser(Guid userId)
        {
            try
            {
                if (((IGroupChat) this).CheckIfUserCanEditMemberIdCollection(userId))
                {
                    if(this._memberCollection.Find(member => member == userId).Equals(null))
                        throw new Exception("there is no such user in this group!");
                    this._memberCollection.Remove(userId);
                }
                else
                {
                    throw new Exception("You have no rights to remove users in this group");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public bool CheckIfUserCanSendMessage(Guid user)
        {
            return this._memberCollection.Contains(user);
        }

        public bool CheckIfUserCanEditMessage(Guid user, Guid messageId)
        {
            IMessage message = base.GetMessageById(messageId);
            if (message.SenderUserId == user)
                return true;
            else
            {
                return false;
            }
        }

        public bool CheckIfUserCanDeleteMessage(Guid user, Guid messageId)
        {
            if (this._adminIdCollection.Contains(user))
            {
                return true;
            }
            else
            {
                IMessage message = base.GetMessageById(messageId);
                if (message.SenderUserId == user)
                    return true;
                else
                {
                    return false;
                }
            }
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
                    throw new Exception("You have no rights to send messages in this group");
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
                if (((IGroupChat) this).CheckIfUserCanEditMessage(oldMessage.SenderUserId, oldmessageId))
                {
                    base.EditMessage(oldmessageId, content);
                }
                else
                {
                    throw new Exception("You have no rights to edit messages in this group");
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
                if (((IGroupChat) this).CheckIfUserCanDeleteMessage(message.SenderUserId, messageId))
                {
                    base.DeleteMessage(messageId);
                }
                else
                {
                    throw new Exception("You have no rights to delete messages in this group");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}