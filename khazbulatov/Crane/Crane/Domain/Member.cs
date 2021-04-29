using System;

namespace Crane.Domain
{
    public class Member : IMember
    {
        public IRole Role { get; }
        public IUser User { get; }
        
        public static Member Parse(string representation)
        {
            throw new NotImplementedException();
        }
        
        public static string Render(Member member)
        {
            throw new NotImplementedException();
        }

        public Member(IUser user, IRole role)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Role = role ?? throw new ArgumentNullException(nameof(role));
        }
    }
}
