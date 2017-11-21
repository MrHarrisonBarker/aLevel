using System;
using aLevel.Controllers;
using ikvm.extensions;
using LinqToTwitter;
using NUnit.Framework;
using Moq;

namespace aLevel.Tests.Controllers.Queries
{
    [TestFixture]
    public class When_getting_tweets
    {
        [Test]
        public void Should_return_valid_tweets()
        {

            var controller = new QueriesController();

            var task = controller.GetTweets("query", 10, ResultType.Mixed);
            //task.RunSynchronously();

            var result = task.Result;

            foreach (var tweet in result)
            {
                Console.WriteLine(tweet.ID);
                Console.WriteLine(tweet.ImageUrl);
                Console.WriteLine(tweet.ScreenName);
                Console.WriteLine(tweet.Text);
                Console.WriteLine(tweet.CreatedAt);
                Console.WriteLine(tweet.IsVerified);
                Console.WriteLine(tweet.RetweetCount);
            }
            
            //Assert.IsEmpty(result);

        }
    }
}
