using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToTwitter;
using System.Threading.Tasks;


namespace aLevel.Controllers
{
    public class QueriesController : Controller
    {
        // GET: Queries
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> HomeTimelineAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            var tweets =
                await
                (from tweet in ctx.Status
                 where tweet.Type == StatusType.Home
                 select new Models.TweetViewModel
                 {
                     ImageUrl = tweet.User.ProfileImageUrl,
                     ScreenName = tweet.User.ScreenNameResponse,
                     Text = tweet.Text
                 })
                .ToListAsync();

            return View(tweets);
        }
    }
}