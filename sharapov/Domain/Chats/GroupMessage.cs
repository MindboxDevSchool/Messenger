namespace Messenger.Domain.Chats
{
    public class GroupMessage
    {
        public IChatRole Sender { get; }
        public Message Message { get; }

        public GroupMessage(IChatRole sender, Message message)
        {
            Sender = sender;
            Message = message;
        }
        
        //TODO override equals 
    }
}