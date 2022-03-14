using com.TweetApp.Entities;
using com.TweetApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.TweetApp.global
{
    public class AutoMapper
    {
        public static IList<UserDTO> MapUserDTO(IList<User> users)
        {
            IList<UserDTO> userDTO = new List<UserDTO>();
            foreach(var user in users)
            {
                var u = new UserDTO();
                u.UserId = user.UserId;
                u.FirstName = user.FirstName;
                u.LastName = user.LastName;
                u.Dob = user.Dob;
                u.Gender = user.Gender;
                u.EmailId = user.EmailId;
                userDTO.Add(u);
            }
            return userDTO;
        }
    }
}
