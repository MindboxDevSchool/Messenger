using System;
using System.Collections.Generic;
using System.Linq;
using Messanger.Domain.MessageModel;

namespace Messanger.Domain.ChatModel
{
    public class Chat : IChat
    {
        protected string _name;
        public string Name
        {
            get { return this._name; }
        }

        protected Guid _id;
        public Guid Id
        {
            get { return this._id; }
        }

        protected List<Guid> _memberCollection;
        public IEnumerable<Guid> MemberIdCollection
        {
            get { return new List<Guid>(this._memberCollection); }
        }

        protected List<IMessage> _messageCollection;
        public IEnumerable<IMessage> MessageCollection
        {
            get { return new List<IMessage>(this._messageCollection); }
        }
        
        public virtual void SendMessage(IMessage message)
        {
            this._messageCollection.Add(message);
        }

        public virtual void EditMessage(Guid oldMessageId, object content)
        {
            IMessage oldMessage = this.GetMessageById(oldMessageId);
            oldMessage.Content = content;
        }

        public virtual void DeleteMessage(Guid messageId)
        {
            this._messageCollection.Remove(this.GetMessageById(messageId));
        }

        protected IMessage GetMessageById(Guid messageId)
        {
            return this._messageCollection.Find(message => message.Id == messageId);
        }

        public Chat(string name, List<Guid> memberCollection)
        {
            this._id = new Guid();
            this._name = name;
            this._memberCollection = new List<Guid>(memberCollection);
            this._messageCollection = new List<IMessage>();
        }

        public Chat()
        {
            
        }
    }
}