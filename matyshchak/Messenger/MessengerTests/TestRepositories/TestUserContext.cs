using System;
using Application;

namespace MessengerTests.TestRepositories
{
    public class TestUserContext : IContext
    {
        private readonly Guid _currentUserId;

        public TestUserContext(Guid currentUserId) => _currentUserId = currentUserId;

        public Guid GetCurrentUserId() => _currentUserId;
    }
}