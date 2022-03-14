using System;
using System.Collections.Generic;

#nullable disable

namespace com.TweetApp.Entities
{
    public partial class Tweet
    {
        public int Id { get; set; }
        public string Tweets { get; set; }
        public int UserId { get; set; }
        public DateTime? Created { get; set; }

        //public virtual User User { get; set; }
    }
}
