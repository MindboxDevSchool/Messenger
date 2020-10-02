using System;
using System.Collections.Generic;
using System.Linq;
using Crane.Domain;
using Crane.Infrastructure;

namespace Crane.Application
{
    public class ChatService
    {
        private readonly IIdentityProvider _idProvider;
        private readonly IRepo<IChat> _chatRepo;

        public ChatService() : this(
            new SequentialIdentityProvider(),
            new FileRepo<IChat>(".cht")
        ) { }

        public ChatService(IIdentityProvider idProvider, IRepo<IChat> chatRepo)
        {
            _idProvider = idProvider ?? throw new ArgumentNullException(nameof(idProvider));
            _chatRepo = chatRepo ?? throw new ArgumentNullException(nameof(chatRepo));
        }

        public PrivateChat CreatePrivateChat(IUser self, IUser peer)
        {
            int id = _idProvider.NextId;
            PrivateChat chat = new PrivateChat(
                id,
                new SequentialIdentityProvider(),
                new FileRepo<IMessage>($".{id}.msg"), 
                self,
                peer
            );
            _chatRepo.Add(chat);
            return chat;
        }
        
        public GroupChat CreateGroupChat(IUser self, IEnumerable<IUser> peers)
        {
            int id = _idProvider.NextId;
            GroupChat chat = new GroupChat(
                id,
                new SequentialIdentityProvider(),
                new FileRepo<IMessage>($".{id}.msg"),
                new FileRepo<IMember>($".{id}.mbr")
            );
            _chatRepo.Add(chat);
            // TODO: Add members
            return chat;
        }
        
        public ChannelChat CreateChannelChat(IUser self)
        {
            int id = _idProvider.NextId;
            ChannelChat chat = new ChannelChat(
                id,
                new SequentialIdentityProvider(),
                new FileRepo<IMessage>($".{id}.msg"),
                new FileRepo<IMember>($".{id}.mbr")
            );
            _chatRepo.Add(chat);
            // TODO: Add members
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
