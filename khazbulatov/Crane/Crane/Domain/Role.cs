using System;
using System.Collections.Generic;

namespace Crane.Domain
{
    public class Role : IRole
    {
        public static Role Nobody = new Role("Nobody", new Permission[0]);
        
        public static Role Viewer = new Role("Viewer", new Permission[]
        {
            Permission.Get
        });
        
        public static Role Participant = new Role("Participant", new Permission[]
        {
            Permission.Get,
            Permission.Send,
            Permission.EditOwn,
            Permission.DeleteOwn
        });
        
        public static Role Author = new Role("Author", new Permission[]
        {
            Permission.Get,
            Permission.Send,
            Permission.EditOwn,
            Permission.DeleteOwn,
            Permission.DeleteAny
        });

        public static Role Administrator = new Role("Administrator", new Permission[]
        {
            Permission.Get,
            Permission.Send,
            Permission.EditOwn,
            Permission.DeleteOwn,
            Permission.DeleteAny
        });
        
        public string Name { get; }
        public IEnumerable<Permission> Permissions { get; }
        
        public Role(string name, IEnumerable<Permission> permissions)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Permissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
        }
    }
}
