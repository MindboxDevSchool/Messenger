using System;
using Application;

namespace MessengerTests
{
    public class TestUserContext : IContext
    {
        public TestUserContext(Guid currentUserId)
        {
            CurrentUserId = currentUserId;
        }

        public Guid CurrentUserId { get; }
    }
}