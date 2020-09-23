namespace Messenger.Domain
{
    public class MessageId {
        private int Id { get; set; }

        private static object sync = new object();
        
        public MessageId(int lastBiggestId) { 
            Id = lastBiggestId;
        }

        public int Increment() {
            lock (sync) {
                Id++;
            }
            return Id;
        }
    }
}