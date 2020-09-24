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
            if (!_messengerSettings.Accesses.TryGetValue(roleType, out var accesses))
            {
                throw new RoleTypeSettingsNotFoundException(roleType);
            }

            return new ChatRole(accesses);
        }

        private MessengerSettings _messengerSettings;
    }
}