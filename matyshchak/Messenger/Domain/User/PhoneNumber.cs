namespace Domain.User
{
    public class PhoneNumber
    {
        public PhoneNumber(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}