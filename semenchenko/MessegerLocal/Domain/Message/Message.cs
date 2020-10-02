using System;

namespace Messeger.Domain
{
    public class Message
    {
        public DateTime Time { get; private set; }
        public string MessageText { get; private set; }
    }
}