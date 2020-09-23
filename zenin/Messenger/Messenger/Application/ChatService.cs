using System;
using System.Collections.Generic;
namespace Messenger
{
    public class ChatService : IChatService
    {
        private List<Guid> _chats;

        public Guid CreateNewChat(IChat chat)
        {
            if (chat == null) throw new ArgumentNullException(nameof(chat));
            _chats.Add(chat.Id);
            return chat.Id;
        }
    }
}