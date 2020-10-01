using System;

namespace Application
{
    public interface IContext
    {
        Guid CurrentUserId { get; }
    }
}