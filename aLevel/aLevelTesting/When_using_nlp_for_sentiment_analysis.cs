using System;
using System.IO;

using FluentAssertions;

using java.util;

using NUnit.Framework;

using SimpleNetNlp;



namespace aLevelTesting
{
	[ TestFixture ]
	public class When_using_nlp_for_sentiment_analysis
	{
		[ Test ]
		public void It_is_a_nice_day_Should_be_positive()
		{
			Directory.SetCurrentDirectory( AppDomain.CurrentDomain.BaseDirectory );
			Console.WriteLine( new DirectoryInfo( "." ).FullName );

			Console.WriteLine( "NLP..." );

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
			};
			foreach (var s in data)
			{
				var sentence = new Sentence( s );
				Console.WriteLine($"{s} : {sentence.Sentiment}");
			}

		}
	}
}
