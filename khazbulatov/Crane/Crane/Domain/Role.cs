using System;
using System.Collections.Generic;

namespace Crane.Domain
{
    public class Role : IRole
    {
        public static readonly Role Nobody = new Role("Nobody", new Permission[0]);
        
        public static readonly Role Viewer = new Role("Viewer", new Permission[]
        {
            Permission.Get
        });
        
        public static readonly Role Participant = new Role("Participant", new Permission[]
        {
            Permission.Get,
            Permission.Send,
            Permission.EditOwn,
            Permission.DeleteOwn
        });
        
        public static readonly Role Author = new Role("Author", new Permission[]
        {
            Permission.Get,
            Permission.Send,
            Permission.EditOwn,
            Permission.DeleteOwn,
            Permission.DeleteAny
        });

        public static readonly Role Administrator = new Role("Administrator", new Permission[]
        {
            Permission.Get,
            Permission.Send,
            Permission.EditOwn,
            Permission.DeleteOwn,
            Permission.DeleteAny
        });
        
        public string Label { get; }
        public IEnumerable<Permission> Permissions { get; }
        
        public Role(string label, IEnumerable<Permission> permissions)
        {
            Label = label ?? throw new ArgumentNullException(nameof(label));
            Permissions = permissions ?? throw new ArgumentNullException(nameof(permissions));
        }
    }
}
