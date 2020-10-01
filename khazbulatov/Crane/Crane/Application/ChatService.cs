using System.Linq;
using Crane.Domain;
using Crane.Infrastructure;

namespace Crane.Application
{
    public class ChatService
    {
        private readonly IIdentityProvider _idProvider;
        private readonly IRepo<IChat> _chatRepo;

        public ChatService()
        {
            _idProvider = new SequentialIdentityProvider();
            _chatRepo = new FileRepo<IChat>(".cht");
        }

        public PrivateChat CreatePrivateChat(IUser self, IUser peer)
        {
            int id = _idProvider.NextId;
            PrivateChat chat = new PrivateChat(
                id,
                new SequentialIdentityProvider(),
                new FileRepo<IMessage>($".{id}.msg"), 
                new Member(self, Role.Participant),
                new Member(peer, Role.Participant)
            );
            _chatRepo.Add(chat);
            return chat;
        }
        
        public GroupChat CreateGroupChat()
        {
            int id = _idProvider.NextId;
            GroupChat chat = new GroupChat(
                id,
                new SequentialIdentityProvider(),
                new FileRepo<IMessage>($".{id}.msg"),
                new FileRepo<IMember>($".{id}.mbr")
            );
            _chatRepo.Add(chat);
            return chat;
        }
        
        public ChannelChat CreateChannelChat()
        {
            int id = _idProvider.NextId;
            ChannelChat chat = new ChannelChat(
                id,
                new SequentialIdentityProvider(),
                new FileRepo<IMessage>($".{id}.msg"),
                new FileRepo<IMember>($".{id}.mbr")
            );
            _chatRepo.Add(chat);
            return chat;
        }
        
        public Maybe<IChat> GetChat(int id)
        {
            IChat chat = _chatRepo.Items.SingleOrDefault((c) => c.Id == id);
            return chat == null
                ? new Maybe<IChat>.None()
                : (Maybe<IChat>) new Maybe<IChat>.Some(chat);
        }
    }
}
