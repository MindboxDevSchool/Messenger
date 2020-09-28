using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class ChanelRepository : IChanelRepository
    {
        private List<IChanel> _chanels;

        public ChanelRepository()
        {
            _chanels = new List<IChanel>();
        }
        
        public IChanel CreateChanel(IUser creator, string name)
        {
            var id = Guid.NewGuid().ToString("N");
            var chanel = new Chanel(id, name, creator);
            _chanels.Add(chanel);
            return chanel;
        }

        public IChanel GetChanel(string chanelId)
        {
            var chanel = _chanels.FirstOrDefault(m => m.Id == chanelId);
            if (chanel == null)
                throw new NotFoundException();
            return chanel;
        }

        public void EditChanel(string chanelId, string newName)
        {
            throw new System.NotImplementedException();
        }

        public void AddMember(string chanelId, IUser member)
        {
            var chanel = GetChanel(chanelId);
            chanel.AddMember(member);
        }

        public void RemoveMember(string chanelId, IUser member)
        {
            var chanel = GetChanel(chanelId);
            chanel.RemoveMember(member);
        }

        public void DeleteChanel(string chanelId)
        {
            _chanels.RemoveAll(c => c.Id == chanelId); 
        }

        public bool HasMember(string chanelId, IUser member)
        {
            var chanel = GetChanel(chanelId);
            return chanel.GetMembers().Any(m => m.Equals(member));
        }
    }
}