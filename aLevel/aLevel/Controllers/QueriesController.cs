using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using aLevel.Models;
using LinqToTwitter;
using System.Collections.Generic;
using System.Data.Entity;

namespace aLevel.Controllers
{
    public class QueriesController : Controller
    {
        // GET: Queries
        public ActionResult Index()
        {
            return View();
        }

        [ActionName("HomeTimeline")]
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
                 select new TweetViewModel  
                 {
                     ImageUrl = tweet.User.ProfileImageUrl,
                     ScreenName = tweet.User.ScreenNameResponse,
                     Text = tweet.Text
                 })
                .ToListAsync();

            return View(tweets);
        }

        [ActionName("Search")]
        public async Task<ActionResult> SearchAsync()
        {
            var auth = new MvcAuthorizer
            {
                CredentialStore = new SessionStateCredentialStore()
            };

            var ctx = new TwitterContext(auth);

            var searchResponse =
                await
                (from search in ctx.Search
                 where search.Type == SearchType.Search &&
                       search.Query == "Donald trump" &&
                       search.Count == 200
                 select search)
                .SingleOrDefaultAsync();

            var tweets =
                (from tweet in searchResponse.Statuses
                 select new TweetSearchModel
                 {
                     ID = tweet.StatusID,
                     ImageUrl = tweet.User.ProfileImageUrl,
                     ScreenName = tweet.User.Name,
                     Text = tweet.Text,
                 })
                 .ToList();

            return View(tweets);
        }
    }
}