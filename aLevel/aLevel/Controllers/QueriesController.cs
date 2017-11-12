using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

using aLevel.Models;

using LinqToTwitter;

using SimpleNetNlp;



namespace aLevel.Controllers
{
	public class QueriesController : Controller
	{

        //		[HttpGet]
        public ActionResult Search()    
        {
            return View();
        }



        //		[HttpPost]
        public async Task<ActionResult> DoSearch( string query, int count, ResultType type )
		{
			var tweets =
				await
					GetTweets( query, count, type );

			var sentimentTweets = DoSentiment( tweets );

			return View( "Results", sentimentTweets );
		}



		public async Task<List<TweetSearchModel>> GetTweets( string query, int count, ResultType type )
		{
			var auth = new MvcAuthorizer
			{
				CredentialStore = new SessionStateCredentialStore()
			};

			var ctx = new TwitterContext( auth );

			var listOfTweets = new List<TweetSearchModel>();

			while( listOfTweets.Count < count )
			{
				ulong maxId = 0;

				if( listOfTweets.Count > 0 )
				{
					maxId = listOfTweets[ listOfTweets.Count - 1 ].ID;
				}

				var numberToRequest = ( count - listOfTweets.Count );

				var searchResponse =
					await
						( from search in ctx.Search
						  where search.Type == SearchType.Search &&
						        search.Query == query &&
						        search.Count == numberToRequest &&
						        search.ResultType == type &&
						        search.MaxID == maxId
						  select search )
						.SingleOrDefaultAsync();


				if( searchResponse.Count < 1 )
				{
					break;
				}


				listOfTweets.AddRange(
				                      from tweet in searchResponse.Statuses
				                      where tweet.RetweetedStatus.RetweetCount < 1
				                      select new TweetSearchModel
				                      {
					                      ID = tweet.ID,
					                      ImageUrl = tweet.User.ProfileImageUrl,
					                      ScreenName = tweet.User.Name,
					                      Text = tweet.Text,
				                          CreatedAt = tweet.CreatedAt,
				                          IsVerified = tweet.User.Verified,
				                          RetweetCount = tweet.RetweetCount
				                      } );
			}


			return listOfTweets;
		}



		public List<SentimentViewModel> DoSentiment( List<TweetSearchModel> tweets )
		{
			Directory.SetCurrentDirectory( AppDomain.CurrentDomain.BaseDirectory );
			//Console.WriteLine(new DirectoryInfo(".").FullName

			var sentimentTweets =
				( from tweet in tweets
				  select new SentimentViewModel()
				  {
					  ImageUrl = tweet.ImageUrl,
					  ScreenName = tweet.ScreenName,
					  Text = tweet.Text,
				      CreatedAt = tweet.CreatedAt,
				      IsVerified = tweet.IsVerified,
				      RetweetCount = tweet.RetweetCount,
                      SentimentText = new Sentence( tweet.Text ).Sentiment.ToString()
				  } )
				.ToList();

			return sentimentTweets;
		}
	}
}
