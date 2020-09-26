using Id = System.String;

namespace Messenger
{

    public enum Role
    {
        Default,
        Admin
    }

    // Receivers

    public interface IEntityWithId
    {
        public Id Id { get; }
        public bool Equals(IEntityWithId other)
        {
            return Id == other.Id;
        }
    }

    public interface IReceiver : IEntityWithId
    {
    }
    

    public interface ISender : IEntityWithId
    {
    }


    // Message

    // Application
    // admin group - create, delete, changeRole, changeName
    // user group - send, edit, delete message, 

    // user registration, change login

    // create chanel, send to chanel, edit, delete

    // chat send, edit, delete message

    // Repositories

}