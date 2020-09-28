using Messenger.Domain;

namespace Usage
{
    public interface IChatterFactory
    {
        Chatter Create(string chatterName, int id);
    }

    class ChatterFactory : IChatterFactory
    {
        public Chatter Create(string chatterName, int id)
        {
            return new Chatter(chatterName, id);
        }

    }
}