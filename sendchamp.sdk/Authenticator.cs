using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendchamp.sdk
{
    public class Authenticator : IAuthenticator
    {
        private readonly SendChampConfig _config;
        public Authenticator(SendChampConfig config)
        {

            _config = config;

        }

        public async ValueTask Authenticate(IRestClient client, RestRequest request)
        {
            var token = $"Bearer {_config.PublicKey}";
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", token);
        }
    }
}
