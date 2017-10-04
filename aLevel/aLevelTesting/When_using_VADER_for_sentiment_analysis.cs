using System;

using FluentAssertions;

using NUnit.Framework;

using VaderSharp;



namespace aLevelTesting
{
	[ TestFixture ]
	public class When_using_VADER_for_sentiment_analysis
	{
		[ Test ]
		public void It_is_a_nice_day_Should_be_positive()
		{
			var analyzer = new SentimentIntensityAnalyzer();
			analyzer.PolarityScores( "It is a nice day" ).Positive.Should().BePositive();

			var data = new[]
			{
				"Go to hell",
				"How do you feel?",
				"The quick brown fox jumped over the lazy dog",
				"I don't really understand what it is you are trying to say",
				"That's bloody amazing!",
				"That's bloody amazing",
				"That's amazing",
				"That's bloody",
				"",
			};
			foreach( var s in data )
			{
				var scores = analyzer.PolarityScores( s );
				Console.WriteLine( $"{s} : {scores.Compound}, {scores.Negative}, {scores.Neutral}, {scores.Positive}" );
			}
		}
	}
}
