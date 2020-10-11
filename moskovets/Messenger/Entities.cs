using System;

namespace Messenger
{
    public enum Role
    {
        Default,
        Admin
    }

    public interface IEntityWithId
    {
        public String Id { get; }
    }

    public static class EntityWithIdExtensions
    {
        public static bool Equals(this IEntityWithId first, IEntityWithId second)
        {
            return first.Id == second.Id;
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

    // create channel, send to channel, edit, delete

    // chat send, edit, delete message

    // Repositories
}