using System;
using Domain;
using Domain.Repositories;

namespace Infrastructure
{
    public class MessageRepository : IRepository<IMessage>
    {
        public void Add(IMessage entity)
        {
            throw new NotImplementedException();
        }

        public IMessage Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(IMessage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}