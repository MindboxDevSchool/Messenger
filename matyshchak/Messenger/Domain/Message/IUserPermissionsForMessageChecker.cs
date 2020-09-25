using System;
using Domain.Chat;
using Domain.User;

namespace Domain
{
    public interface IUserPermissionsForMessageChecker
    {
        bool HasPermissionsToDelete(IUser user, IChat chat);
        bool HasPermissionsToPost(IUser user, IChat chat);
        bool HasPermissionsToEdit(IUser user, IChat chat);
        bool HasPermissionsToPostInChat(Guid userId, Guid chatId);
        bool HasPermissionsToPostInChat(Guid userId, Guid chatId);

    }
}