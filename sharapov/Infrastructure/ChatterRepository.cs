using System.Collections.Generic;
using Messenger.Domain;

namespace Messenger.Infrastructure
{
    public class ChatterRepository : IChatterRepository
    {
        
        private readonly Dictionary<int, IChatRole> _chattersDictionary = new Dictionary<int, IChatRole>();
        
        void SaveChatter(IChatRole chatRole) {
            _chattersDictionary[chatRole.UserId] = chatRole;
        }

        void DeleteChatter(IChatRole chatRole) {
            _chattersDictionary.Remove(chatRole.UserId);
        }
    }
}