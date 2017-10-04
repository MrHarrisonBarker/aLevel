using System.Web.Mvc;

using aLevel.Controllers;

using FluentAssertions;

using Moq;

using NUnit.Framework;



namespace aLevelTesting
{
//	[ TestFixture ]
//	public class When_going_to_the_index_page
//	{
//		[ Test ]
//		public void Should_use_the_index_view_if_authenticated()
//		{
//			var credentialCheckerMock = new Mock<ICredentialChecker>();
//			credentialCheckerMock.Setup( x => x.HasCredentials() ).Returns( true );
//
//			var controller = new HomeController( credentialCheckerMock.Object );
//
//			var result = (ViewResult)controller.Index();
//
//			result.ViewName.Should().Be( "Index" );
//		}
//
//
//
//		[ Test ]
//		public void Should_redirect_to_oath_if_not_authenticated()
//		{
//			var credentialCheckerMock = new Mock<ICredentialChecker>();
//			credentialCheckerMock.Setup( x => x.HasCredentials() ).Returns( false );
//
//			var controller = new HomeController( credentialCheckerMock.Object );
//			var result = (RedirectToRouteResult)controller.Index();
//
//			result.RouteValues[ "action" ].Should().Be( "Index" );
//			result.RouteValues[ "controller" ].Should().Be( "OAuth" );
//		}
//	}
}
