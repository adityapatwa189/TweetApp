using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.TweetApp.Modals
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
    }
}
