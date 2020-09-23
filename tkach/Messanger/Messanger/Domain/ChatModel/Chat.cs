using System;
using System.Collections.Generic;
using System.Linq;
using Messanger.Domain.MessageModel;

namespace Messanger.Domain.ChatModel
{
    public class Chat : IChat
    {
        private string _name;
        public string Name
        {
            get { return this._name; }
        }

        private Guid _id;
        public Guid Id
        {
            get { return this._id; }
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

        private List<Guid> _memberCollection;
        public IEnumerable<Guid> MemberIdCollection
        {
            get { return new List<Guid>(this._memberCollection); }
        }

        private List<IMessage> _messageCollection;
        public IEnumerable<IMessage> MessageCollection { get; }
        
        public void SendMessage(IMessage message)
        {
            this._messageCollection.Add(message);
        }

        public void EditMessage(Guid oldMessageId, object content)
        {
            IMessage oldMessage = this._messageCollection.Find(message => message.Id == oldMessageId);
            oldMessage.Content = content;
        }

        public void DeleteMessage(Guid messageId)
        {
            this._messageCollection.Remove(this._messageCollection.Find(message => message.Id == messageId));
        }
    }
}