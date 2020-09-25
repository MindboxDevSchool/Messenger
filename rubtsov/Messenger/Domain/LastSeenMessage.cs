namespace Messenger.Domain
{
    public class LastSeenMessage
    {
        public string Content { get; set; }
        public bool HaveNewMessages { get; set; }

        public LastSeenMessage()
        {
            HaveNewMessages = false;
        }
    }
}