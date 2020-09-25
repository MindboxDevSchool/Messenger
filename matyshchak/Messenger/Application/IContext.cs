using System;

namespace Application
{
    public interface IContext
    {
        Guid GetUserId();
    }
}