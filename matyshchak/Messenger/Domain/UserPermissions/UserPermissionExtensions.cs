using System.Linq;
using Domain.Chats;
using Domain.Message;
using Domain.User;

namespace Domain.UserPermissions
{
    public static class UserPermissionExtensions
    {
        public static bool IsMemberOf(this IUser user, IChat chat) =>
            user.Chats.Any(userChat => userChat.Id == chat.Id);

        public static bool IsAdminOf(this IUser user, IHasAdmins chat) =>
            chat.Admins.Any(admin => admin.Id == user.Id);

        public static bool IsOwnerOf(this IUser user, IHasOwner chat) =>
            chat.Owner.Id == user.Id;
        
        public static bool IsAuthorOf(this IUser user, IMessage message) =>
            message.Author.Id == user.Id;

        public static bool HasPermissionToPostTo(this IUser user, IChat chat)
        {
            if (chat is IChannel channel)
                return user.IsOwnerOf(channel);
            return true;
        }

        public static bool HasPermissionToReadFrom(this IUser user, IChat chat) =>
            user.IsMemberOf(chat);

        public static bool HasPermissionToEdit(this IUser user, IMessage message) =>
            user.IsAuthorOf(message);

        public static bool HasPermissionToDeleteMessage(this IUser user, IMessage message) =>
            user.IsAuthorOf(message) 
            || message.Chat is IGroup group && user.IsAdminOf(@group);
    }
}