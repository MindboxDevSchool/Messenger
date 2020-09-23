using System;
using System.Collections.Generic;
using Messenger.Domain.Chats;

namespace Messenger.Domain
{
    //dont save messages on server side. Messages doesn't persist 
    public class PrivateChat : IPrivateChat
    {
        private readonly Chatter _firstChatter;
        private readonly Chatter _secondChatter;

        public PrivateChat(Chatter firstChatter, Chatter secondChatter)
        {
            _firstChatter = firstChatter;
            _secondChatter = secondChatter;
        }
        
        public OperationStatus AddMessage(Chatter chatter, string textMessage)
        {
            if (chatter == null) throw new ArgumentNullException(nameof(chatter));
            if (_firstChatter != chatter || _secondChatter != chatter)
            {
                return OperationStatus.NoSuchChatter;
            }

            var localMsgId = 422; //TODO generates form local session 
            if (_firstChatter == chatter)
            {
                NotifyChatter(_secondChatter, new Message(textMessage, localMsgId, chatter.UserId));
            }

            if (_secondChatter == chatter)
            {
                NotifyChatter(_firstChatter, new Message(textMessage, localMsgId, chatter.UserId));
            }
            
            return OperationStatus.Success;
        }

        private static void NotifyChatter(ISubscriber chatter, Message message)
        {
            chatter.Update(message);
        }
    }
}