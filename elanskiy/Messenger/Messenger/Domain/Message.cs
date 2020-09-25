using System;
using System.Collections;
using System.Collections.Generic;

namespace Messenger.Domain
{
    public class Message
    {
        public Guid Id { get; }
        
        public Guid CreatedBy { get; }

        public Guid To { get; }

        public DateTime CreatedOn { get; }

        public string Text { get; set; }

        public Message(Guid id, Guid from, Guid to, string text)
        {
            Id = id;
            Text = text;
            CreatedBy = from;
            To = to;
            CreatedOn = DateTime.UtcNow;
        }

    }
    
}