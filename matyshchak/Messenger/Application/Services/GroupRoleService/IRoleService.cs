using System;

namespace Application.Services.GroupRoleService
{
    public interface IRoleService
    {
        public void PromoteToAdmin(Guid userToPromoteId, Guid groupId);
        public void DemoteFromAdmin(Guid userToDemoteId, Guid groupId);
    }
}