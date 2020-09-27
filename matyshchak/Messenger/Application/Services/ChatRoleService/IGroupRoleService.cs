using System;

namespace Application.Services.ChatRoleService
{
    public interface IGroupRoleService
    {
        public void MakeUserGroupAdmin(Guid userId, Guid chatId);
        public void MakeUserRegularGroupMember(Guid userId, Guid chatId);
    }
}