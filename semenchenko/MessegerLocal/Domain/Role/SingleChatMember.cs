using System.Collections.Generic;
using System.Linq;

namespace Messeger.Domain.Role
{
    public class SingleChatMember : Role
    {
        protected override void SetRights()
        {
            Rights.Add(Right.BlockingOtherUsers);
            Rights.Add(Right.WritingMessages);
            Rights.Add(Right.ViewingMessages);
        }
    }
}