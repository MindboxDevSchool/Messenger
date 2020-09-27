using System;
using Domain.Message;
using Domain.Repositories;

namespace Infrastructure.Repositories
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