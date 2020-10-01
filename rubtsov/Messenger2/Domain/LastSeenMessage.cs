namespace Messenger2.Domain.Channel
{
    public class LastSeenMessage
    {
        public string Content { get; set; }
        public bool HaveNewMessages { get; set; }

        public LastSeenMessage()
        {
            HaveNewMessages = true;
        }
    }
}