using System.Web.Mvc;
using aLevel.Controllers;
using FluentAssertions;
using NUnit.Framework;

namespace aLevel.Tests.Controllers.Queries
{
    [ TestFixture ]
    public class When_going_to_the_search_page
    {
        [ Test ]
        public void Should_return_search_view()
        {
            var controller = new QueriesController();

            var result = (ViewResult)controller.Search();

            result.ViewName.Should().Be( "Search" );
        }
    }
}