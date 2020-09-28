namespace Messenger.Domain
{
    public class MessageIdGenerator : IMessageIdGenerator
    {
        private int Id { get; set; }

        private static object sync = new object();
        
        public MessageIdGenerator(int lastBiggestId) { 
            Id = lastBiggestId;
        }

        public int GetNextMessageId() {
            lock (sync) {
                Id++;
            }
            return Id;
        }
    }
}