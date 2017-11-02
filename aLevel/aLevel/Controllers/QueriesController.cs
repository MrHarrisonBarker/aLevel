using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using aLevel.Models;
using LinqToTwitter;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using Microsoft.Owin.Security.DataHandler;
using SimpleNetNlp;
using java.util;

namespace aLevel.Controllers
{
    public class QueriesController : Controller
    {
        // GET: Queries
        public ActionResult Index()
        {
            return View();
        }

//		[HttpGet]
	    public async Task<ActionResult> Search()
	    {
		    return View();
	    }


//		[HttpPost]
        public async Task<ActionResult> DoSearch( string query, int count, ResultType type )
        {
            var tweets =
                await
                    GetTweets(query, count, type);

            var sentimentTweets =
                await
                    DoSentiment(tweets);

            return View( sentimentTweets );
        }

        public async Task<List<TweetSearchModel>> GetTweets(string query, int count, ResultType type)
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
                              search.Query == query &&
                              search.Count == count &&
                              search.ResultType == type
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

            return (tweets);
        }

        public async Task<List<SentimentViewModel>> DoSentiment(List<TweetSearchModel> tweets)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            //Console.WriteLine(new DirectoryInfo(".").FullName
            
            var sentimentTweets =
                (from tweet in tweets
                    select new SentimentViewModel()
                    {
                        ID = tweet.ID,
                        ImageUrl = tweet.ImageUrl,
                        ScreenName = tweet.ScreenName,
                        Text = tweet.Text,
                        SentimentText = new Sentence(tweet.Text).Sentiment.ToString()
                        
                    })
                .ToList();
            
            return (sentimentTweets);
        }

    }
}