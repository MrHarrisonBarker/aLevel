using aLevel.Controllers;
using FluentAssertions;
using NUnit.Framework;

namespace aLevel.Tests.Controllers.OAuth
{
    [TestFixture]
    public class When_Begin_async
    {
        [Test]
        public void Should_begin_authorisation()
        {
            var controller = new OAuthController();

            var task = controller.BeginAsync();
            task.RunSynchronously();

            var result = task.Result;
            
        }
    }
}
