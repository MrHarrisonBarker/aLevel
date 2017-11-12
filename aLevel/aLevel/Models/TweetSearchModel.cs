using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aLevel.Models
{
    public class TweetSearchModel
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

        internal object ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
