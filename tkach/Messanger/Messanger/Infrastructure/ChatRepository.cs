using System;
using System.Collections.Generic;
using Messanger.Domain.ChatModel;

namespace Messanger.Infrastructure
{
    
    public class ChatRepository : IChatRepository
    {
        private Dictionary<Guid, IChat> _chats;
        public Dictionary<Guid, IChat> Chats
        {
            get { return new Dictionary<Guid, IChat>(this._chats); }
        }

        public ChatRepository(Dictionary<Guid, IChat> chats)
        {
            this._chats = new Dictionary<Guid, IChat>(chats);
        }
        
        public IChat Load(Guid chatId)
        {
            try
            {
                if (this._chats.ContainsKey(chatId))
                {
                    return this._chats[chatId];
                }
                else
                {
                    throw new Exception($"there is no such chat with Guid {chatId}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void Save(IChat chat)
        {
            try
            {
                if(chat.Equals(null))
                    throw new Exception($"IMessage entity is null");
                else
                {
                    this._chats.Add(chat.Id, chat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}