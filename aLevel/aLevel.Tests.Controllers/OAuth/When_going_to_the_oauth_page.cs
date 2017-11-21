using System.Web.Mvc;
using aLevel.Controllers;
using FluentAssertions;
using NUnit.Framework;

namespace aLevel.Tests.Controllers.OAuth
{
    [TestFixture]
    public class When_going_to_the_oauth_page
    {
        [Test]
        public void Should_return_search_oauth_page()
        {
            var controller = new OAuthController();

            var result = (ViewResult)controller.Index();

            result.ViewName.Should().Be("Index");
        }
    }
}
