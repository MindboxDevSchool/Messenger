using Crane.Domain;

namespace Crane.Infrastructure
{
    public class SequentialIdentityProvider : IIdentityProvider
    {
        private int _nextId;
        public int NextId => _nextId++;

        public SequentialIdentityProvider(int nextId = 0)
        {
            _nextId = nextId;
        }
    }
}
