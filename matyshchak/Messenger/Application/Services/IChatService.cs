using System;
using Domain.Chat;

namespace Application.Services
{
    public interface IChatService
    {
        Guid CreateGroup(GroupName groupName, );
        Guid CreateChannel();
    }
}