using System;

namespace Messenger.Domain
{
    public interface IChanelRepository
    {
        IChanel CreateChanel(IUser creator, string name);
        IChanel GetChanel(String chanelId);
        void EditChanel(String chanelId, string newName);
        void AddMember(String chanelId, IUser member);
        void RemoveMember(String chanelId, IUser member);
        void DeleteChanel(String chanelId);
        bool HasMember(String chanelId, IUser member);
    }
}