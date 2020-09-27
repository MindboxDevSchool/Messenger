using System;

namespace Application
{
    public interface IContext
    {
        Guid GetCurrentUserId();
    }
}