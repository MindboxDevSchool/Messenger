using System;
using System.Data;

namespace Messanger.Domain.MessageModel
{
    public class SimpleMessage : IMessage
    {
        private Guid _id;
        public Guid Id
        {
            get { return this._id; }
        }

        private object _content;
        public object Content
        {
            get { return this._content;}
            set { _content = value; this._editDateTime = DateTime.Now; }
        }

        private DateTime _creationDateTime;
        public DateTime CreationDateTime
        {
            get { return this._creationDateTime; }
        }
        
        private DateTime _editDateTime;
        public DateTime EditDateTime
        {
            get { return this._editDateTime; }
        }

        public SimpleMessage(object content)
        {
            this._id = new Guid();
            this._content = content;
            this._creationDateTime = DateTime.Now;
            this._editDateTime = this._creationDateTime;
        }
    }
}