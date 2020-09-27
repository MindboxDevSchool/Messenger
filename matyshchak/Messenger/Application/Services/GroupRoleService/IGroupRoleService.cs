using System;

namespace Application.Services.GroupRoleService
{
    public interface IGroupRoleService
    {
        public void MakeUserGroupAdmin(Guid userId, Guid chatId);
        public void MakeUserRegularGroupMember(Guid userId, Guid chatId);
    }
}