namespace Messeger.Domain.Role
{
    public class ChannelMember : Role
    {
        protected override void SetRights()
        {
            Rights.Add(Right.ViewingMessages);
        }
    }
}