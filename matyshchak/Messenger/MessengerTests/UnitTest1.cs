using Application.Services;
using Domain.User;
using NUnit.Framework;
using Usage;

namespace MessengerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var compositionRoot = CompositionRoot.Create();
            var user = compositionRoot.UserService.Register(new UserName(), new PhoneNumber());
        }
    }
}