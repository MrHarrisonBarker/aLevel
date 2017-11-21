using System;
using aLevel.Controllers;
using aLevel.Models;
using NUnit.Framework;
using System.Collections.Generic;


namespace aLevel.Tests.Controllers.Queries
{
    [TestFixture]
    public class When_doing_sentiment
    {
        [Test]
        public void Should_return_positive()
        {
            var positiveTweets = new List<TweetSearchModel>();
            positiveTweets.Add(new TweetSearchModel()
            {
                ID = 1,
                ScreenName = "test1",
                CreatedAt = DateTime.Today,
                IsVerified = false,
                ImageUrl = "",
                RetweetCount = 0,
                Text = "That's amazing"
            });
            positiveTweets.Add(new TweetSearchModel()
            {
                ID = 2,
                ScreenName = "test2",
                CreatedAt = DateTime.Today,
                IsVerified = false,
                ImageUrl = "",
                RetweetCount = 100,
                Text = "That's awesome!"
            });
            

            var controller = new QueriesController();

            var result = controller.DoSentiment(positiveTweets);

            var isPositive = new int();
            
            foreach (var tweet in result)
            {
                var sentence = tweet.SentimentText;

                Console.WriteLine("Text: " + tweet.Text);
                Console.WriteLine("Sentiment: " + tweet.SentimentText);

                if (sentence == "Positive")
                {
                    isPositive ++;
                }

            }

            Assert.IsTrue(isPositive == result.Count);
        }

        [Test]
        public void Should_return_negative()
        {
            var negativeTweets = new List<TweetSearchModel>();
            negativeTweets.Add(new TweetSearchModel()
            {
                ID = 1,
                ScreenName = "test1",
                CreatedAt = DateTime.Today,
                IsVerified = false,
                ImageUrl = "",
                RetweetCount = 0,
                Text = "That's awful"
            });
            negativeTweets.Add(new TweetSearchModel()
            {
                ID = 2,
                ScreenName = "test2",
                CreatedAt = DateTime.Today,
                IsVerified = false,
                ImageUrl = "",
                RetweetCount = 100,
                Text = "That's terrible!"
            });


            var controller = new QueriesController();

            var result = controller.DoSentiment(negativeTweets);

            var isNegative = new int();

            foreach (var tweet in result)
            {
                var sentence = tweet.SentimentText;

                Console.WriteLine("Text: " + tweet.Text);
                Console.WriteLine("Sentiment: " + tweet.SentimentText);

                if (sentence == "Negative")
                {
                    isNegative ++;
                }

            }

            Assert.IsTrue(isNegative == result.Count);
        }
    }
}
