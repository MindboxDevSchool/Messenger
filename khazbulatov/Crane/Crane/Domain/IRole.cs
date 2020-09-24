using System.Collections.Generic;

namespace Crane.Domain
{
    public interface IRole
    {
        IEnumerable<Permission> Permissions { get; }
        string Name { get; }
    }
}
