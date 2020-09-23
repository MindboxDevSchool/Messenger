using System;

namespace Application
{
    public interface IContextAccessor
    {
        bool CheckUserClaim(string type, string value);
        Guid GetUserId();
    }
}