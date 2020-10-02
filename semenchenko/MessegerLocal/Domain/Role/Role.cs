using System.Collections.Generic;

namespace Messeger.Domain.Role
{
    public abstract class Role
    {
        protected HashSet<Right> Rights;

        public Role()
        {
            Rights = new HashSet<Right>();
            SetRights();
        }

        protected abstract void SetRights();

        public bool CheckRight(Right right)
        {
            return Rights.Contains(right);
        }
    }
}