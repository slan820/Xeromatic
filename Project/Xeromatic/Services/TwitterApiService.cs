using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweet = Xeromatic.Models.Tweet;
using System.Linq;


namespace Xeromatic.Services
{
    public class TwitterApiService:ITwitterService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "gPWnWKttPAlLVHDjBMogEdcDE",
                ConsumerSecret = "3W10sg46ztsmjkxVhogdqRHpeOVQ0pMwgJdHSnt22I7kSKAw01",
                AccessToken = "718557150985871360-jYSOZA69GQEf3PlOrVso6ugATBpkmJI",
                AccessTokenSecret = "53XlIzrRdcqglbh5Nku5ZhuWynUhQJHJIBq0PaShXIdLH"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = Auth.ExecuteOperationWithCredentials(_creds, () => Timeline.GetUserTimeline("TheRealSarahJL", 10)).ToList();

            if (tweets.Any())
            {
                return tweets.Select(t => new Tweet
                {
                    Id = t.Id,
                    Text = t.Text
                });
            }
            return new List<Tweet>();

        }

    }
}