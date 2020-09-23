namespace Messenger.Domain
{
    public class Chatter : IChatRole, ISubscriber
    {
        public string UserName { get; }
        public int UserId { get; }

        public Chatter(string userName, int userId)
        {
            UserName = userName;
            UserId = userId;
        }
        
        public void Update(Message message)
        {
            //TODO which way does information go?
            //TODO Who is the receiver? Infrastructure? UI? Port-Adapter?
            throw new System.NotImplementedException();
        }
    }
}