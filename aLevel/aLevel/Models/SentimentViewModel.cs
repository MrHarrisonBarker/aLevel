using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aLevel.Models
{
    public class SentimentViewModel
    {
        [DisplayName("Tweet ID")]
        public ulong ID { get; set; }

        [DisplayName("Image")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DisplayName("Screen Name")]
        public string ScreenName { get; set; }

        [DisplayName("Tweet")]
        public string Text { get; set; }

        [DisplayName("Created at")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Verified")]
        public bool IsVerified { get; set; }

        [DisplayName("Retweet Count")]
        public int RetweetCount { get; set; }

        [DisplayName("Tweet sentiment")]
        public string SentimentText { get; set; }

        [DisplayName("Follower Count")]
        public int FollowerCount { get; set; }

        [DisplayName("StatusesCount")]
        public int StatusesCount { get; set; }

        [DisplayName("Lang")]
        public string Lang { get; set; }

        [DisplayName("FavoriteCount")]
        public int? FavoriteCount { get; set; }

        internal object ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
