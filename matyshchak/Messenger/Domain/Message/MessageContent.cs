namespace Domain.Message
{
    public class MessageContent
    {
        public MessageContent(string text)
        {
            Text = text;
        }

        public string Text { get; }
    }
}