using System.Collections.Generic;

namespace Messeger.Domain.Role
{
    public class ChannelAuthor : Role
    {
        protected override void SetRights()
        {
            Rights.Add(Right.ChangingAvatar);
            Rights.Add(Right.ChangingTitle);
            Rights.Add(Right.WritingMessages);
            Rights.Add(Right.ViewingMessages);
            Rights.Add(Right.ChangeOtherUsersRoles);
        }
    }
}