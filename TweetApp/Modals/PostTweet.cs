using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.TweetApp.Modals
{
    public class PostTweet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Tweets { get; set; }
    }
}
