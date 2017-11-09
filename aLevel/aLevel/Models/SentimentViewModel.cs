using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace aLevel.Models
{
    public class SentimentViewModel
    {
        [DisplayName("Image")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DisplayName("Screen Name")]
        public string ScreenName { get; set; }

        [DisplayName("Tweet")]
        public string Text { get; set; }

        [DisplayName("Tweet sentiment")]
        public string SentimentText { get; set; }

        internal object ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
