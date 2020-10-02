namespace Messeger.Domain.Role
{
    public class ConversationMember : Role
    {
        protected override void SetRights()
        {
            Rights.Add(Right.ViewingMessages);
            Rights.Add(Right.WritingMessages);
        }
    }
}