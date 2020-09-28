namespace Messenger.Domain
{
    public interface IChatRole
    {
        string UserName { get;}
        int UserId {get;}
    }
    
    //TODO override Equals to compare by UserId
}