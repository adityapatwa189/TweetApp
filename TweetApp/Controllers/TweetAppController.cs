using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using com.TweetApp.Entities;
using User = com.TweetApp.Entities.User;
using com.TweetApp.Service;
using com.TweetApp.Modals;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace com.TweetApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetAppController : ControllerBase
    {
        private readonly ITweetAppService tweetAppService;
        private ILogger<TweetAppController> logger;

        public TweetAppController(ITweetAppService tweetAppService, ILogger<TweetAppController> logger)
        {
            this.tweetAppService = tweetAppService;
            this.logger = logger;
        }

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>response message</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var result = await this.tweetAppService.UserRegister(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while registering user");
                throw;
            }
        }
        /// <summary>
        /// tweets by a specific user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of tweets.</returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<Tweet>))]
        [Route("usertweets")]
        public async Task<IActionResult> GetTweetsByUser(int userId)
        {
            try
            {
                var result = await this.tweetAppService.GetTweetsByUser(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while getting tweets.");
                throw;
            }
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="password"></param>
        /// <returns>response message.</returns>
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string emailID, string password)
        {
            try
            {
                var result = await this.tweetAppService.UserLogin(emailID, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while logging in.");
                throw;
            }
        }

        /// <summary>
        /// Post new Tweet.
        /// </summary>
        /// <param name="tweet"></param>
        /// <returns>response message.</returns>
        [HttpPost]
        [Route("tweet")]
        public async Task<IActionResult> Tweet(PostTweet tweet)
        {
            try
            {
                var result = await this.tweetAppService.PostTweet(tweet);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while posting tweet.");
                throw;
            }
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>list of users.</returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(List<UserDTO>))]
        [Route("allusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await this.tweetAppService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while getting all user.");
                throw;
            }
        }
        /// <summary>
        /// Forget password.
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword(string emailId, string password)
        {
            try
            {
                var result = await this.tweetAppService.ForgotPassword(emailId, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while resetting password.");
                throw;
            }
        }
        /// <summary>
        /// update password.
        /// </summary>
        /// <param name="emailId"></param>
        /// <param name="oldpassword"></param>
        /// <param name="newPassword"></param>
        /// <returns>response</returns>
        [HttpPut]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        [Route("updatepassword")]
        public async Task<IActionResult> UpdatePassword(string emailId, string oldpassword, string newPassword)
        {
            try
            {
                var result = await this.tweetAppService.UpdatePassword(emailId, oldpassword, newPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while updating password.");
                throw;
            }
        }

        /// <summary>
        /// Get All Tweets.
        /// </summary>
        /// <returns>list of tweets.</returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK,Type= typeof(List<Tweet>))]
        [Route("alltweets")]
        public async Task<IActionResult> GetAllTweets()
        {
            try
            {
                var result = await this.tweetAppService.GetAllTweets();
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, $"Error occured while getting all tweets.");
                throw;
            }
        }
    }
}
