using System.Diagnostics;

namespace Messenger.Domain
{
    public class RolesFactory : IRolesFactory
    {
        public RolesFactory(MessengerSettings messengerSettings)
        {
            _messengerSettings = messengerSettings;
        }

        public ChatRole Create(RoleType roleType)
        {
            return new ChatRole(_messengerSettings.Accesses[roleType]);
        }

        private MessengerSettings _messengerSettings;
    }
}