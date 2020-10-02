namespace Messeger.Domain.Role
{
    public class ConversationAdmin : Role
    {
        protected override void SetRights()
        {
            Rights.Add(Right.ChangingAvatar);
            Rights.Add(Right.ChangingTitle);
            Rights.Add(Right.ViewingMessages);
            Rights.Add(Right.WritingMessages);
            Rights.Add(Right.ChangeOtherUsersRoles);
            Rights.Add(Right.BlockingOtherUsers);
        }
    }
}