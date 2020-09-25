using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.Domain;

namespace Messenger
{
    public class ChatRepository : IChatRepository
    {
        private List<IChat> Chats { get; }

        public ChatRepository()
        {
            Chats = new List<IChat>();
        }

        public IChat Load(Guid chatId)
        {
            try
            {
                return Chats.Single(chat => chat.Id == chatId);
            }
            catch (Exception)
            {
                throw new NotFoundException("Chat with selected id not found!");
            }
        }

        public void Save(IChat chat)
        {
            if (chat == null) throw new ArgumentNullException(nameof(chat));
            if (Chats.Count(chatInList => chatInList == chat) == 0)
            {
                Chats.Add(chat);
            }
        }
    }
}