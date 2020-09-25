using System;
using System.Collections.Generic;
using Messenger.Domain;
using Messenger;

namespace Messenger.Application
{
    public class ChatService : IChatService
    {
        public IChatRepository ChatRepository { get; }
        public IMessageRepository MessageRepository { get; }
        
        public ChatService(IChatRepository chatRepository, IMessageRepository messageRepository)
        {
            ChatRepository = chatRepository ?? throw new ArgumentNullException(nameof(chatRepository));
            MessageRepository = messageRepository ?? throw new ArgumentNullException(nameof(messageRepository));
        }

        public Guid CreatePrivateChat(IUser userActing, IUser userChatter)
        {
            if (userActing == null) throw new ArgumentNullException(nameof(userActing));
            if (userChatter == null) throw new ArgumentNullException(nameof(userChatter));
            var chatId = Guid.NewGuid();
            ChatRepository.Save(new PrivateChat(
                chatId,
                new List<IUser>() { userActing },
                new List<IUser>() { userActing, userChatter },
                new List<IMessage>()
                ));
            return chatId;
        }
        
        public Guid CreateGroupChat(IUser userActing)
        {
            if (userActing == null) throw new ArgumentNullException(nameof(userActing));
            var chatId = Guid.NewGuid();
            ChatRepository.Save(new GroupChat(
                chatId,
                new List<IUser>() { userActing },
                new List<IUser>() { userActing },
                new List<IMessage>()
            ));
            return chatId;
        }
        
        public Guid CreateChanel(IUser userActing)
        {
            if (userActing == null) throw new ArgumentNullException(nameof(userActing));
            var chatId = Guid.NewGuid();
            ChatRepository.Save(new Chanel(
                chatId,
                new List<IUser>() { userActing },
                new List<IUser>() { userActing },
                new List<IMessage>()
            ));
            return chatId;
        }
        
        public void JoinChat(IChat chat, IUser user)
        {
            chat.AddUser(user);
        }
        
        public void LeaveChat(IChat chat, IUser user)
        {
            chat.DeleteUser(user, user);
        }

        public void DeleteUser(IChat chat, IUser userActing, IUser userToDelete)
        {
            chat.DeleteUser(userActing, userToDelete);
        }

        public Guid SendMessage(IChat chat, IUser userActing, string messageText)
        {
            var message = new Message(userActing, messageText, chat, Guid.NewGuid());
            chat.AddMessage(message);
            MessageRepository.Save(message);
            return message.Id;
        }

        public void DeleteMessage(IUser userActing, IMessage message)
        {
            message.Chat.DeleteMessage(userActing, message);
        }

        public void EditMessage(IUser userActing, IMessage message, string messageText)
        {
            message.Chat.EditMessage(userActing, message, messageText);
        }
    }
}