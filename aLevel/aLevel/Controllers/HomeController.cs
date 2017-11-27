using System.Web.Mvc;



namespace aLevel.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICredentialChecker credentialChecker;

		public HomeController( ) : this( null )
		{
		    
		}

		public HomeController(ICredentialChecker credentialChecker)
	    {
			this.credentialChecker = credentialChecker ?? new SessionStateCredentialChecker();
	    }



	    public ActionResult Index()
	    {
	        bool currentlyTesting = true;

            if ( !credentialChecker.HasCredentials() && currentlyTesting == false)
	        {
		        return RedirectToAction("Index", "OAuth");
	        }

            return View("Index");
        }

    }
}