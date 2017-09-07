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
	        if( !credentialChecker.HasCredentials() )
	        {
		        return RedirectToAction("Index", "OAuth");
	        }

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Status()
        {
            ViewBag.Message = "Your Status page.";

            return View();
        }

    }
}