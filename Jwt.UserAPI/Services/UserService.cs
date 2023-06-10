using Jwt.UserAPI.Dto;
using RestSharp;

namespace Jwt.UserAPI.Services
{
    public class UserService : IUserService
    {
        private const int _nextLoginMinute = 60;
        private static DateTime nextLoginDate = DateTime.Now.AddMinutes(_nextLoginMinute);
        private static string lastToken;
        private readonly IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Auth()
        {
            if (DateTime.Now < nextLoginDate && !string.IsNullOrEmpty(lastToken))
                return lastToken;

            var client = new RestClient(_configuration["Api:TokenApiUrl"] + "Authenticate/getToken");
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            var response= client.ExecuteGet<AuthDto>(request);

            lastToken = response.Data.AccessToken;

            return response.Data.AccessToken;
        }
    }
}
