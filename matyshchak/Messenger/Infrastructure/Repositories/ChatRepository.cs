using System;
using Domain.Chat;
using Domain.Repositories;

namespace Infrastructure
{
    public class ChatRepository : IRepository<IChat>
    {
        public void Add(IChat entity)
        {
            throw new NotImplementedException();
        }

        public IChat Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(IChat entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}