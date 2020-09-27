using System;
using System.Linq;
using Domain.Chats;
using Domain.Message;

namespace Domain.User
{
    public static class UserPermissionExtensions
    {
        public static bool IsMemberOfChat(this IUser user, IChat chat)
            => user.Chats.Any(userChat => userChat.Id == chat.Id);

        public static bool IsGroupAdmin(this IUser user, IGroup group) =>
            group.Admins.Any(admin => admin.Id == user.Id);

        public static bool IsMessageAuthor(this IUser user, IMessage message)
            => message.AuthorId == user.Id;

        public static bool HasPermissionToPostMessage(this IUser user, IChat chat)
        {
            if (!user.IsMemberOfChat(chat))
                throw new Exception();

            if (chat is IChannel channel)
                return channel.Owner.Id == user.Id;

            return true;
        }

        public static bool HasPermissionToReadFromChat(this IUser user, IChat chat) =>
            user.IsMemberOfChat(chat);

        public static bool HasPermissionToEditMessage(this IUser user, IMessage message)
        {
            if (!user.IsMemberOfChat(message.Chat))
                throw new Exception();

            return user.IsMessageAuthor(message);
        }
        
        public static bool HasPermissionToDeleteMessage(this IUser user, IMessage message)
        {
            if (!user.IsMemberOfChat(message.Chat))
                throw new Exception();

            return user.IsMessageAuthor(message) 
                   || message.Chat is IGroup group && user.IsGroupAdmin(group);
        }
    }
}