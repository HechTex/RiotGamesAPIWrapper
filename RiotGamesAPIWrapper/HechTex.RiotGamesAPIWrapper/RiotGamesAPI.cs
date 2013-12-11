using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace HechTex.RiotGamesAPIWrapper
{
    /// <summary>
    /// Main access point to the HechTex.RiotGamesAPIWrapper library. 
    /// Needs to be supplied with a valid API key to correctly fetch results.
    /// </summary>
    public sealed class RiotGamesAPI
    {
        private const string API_BASE_URL = @"http://prod.api.pvp.net/";

        // value fields
        private string _apiKey;

        // "action" fields
        private RestClient _client;

        // constructor is private to prevent misuse
        private RiotGamesAPI()
        {
            _client = new RestClient(API_BASE_URL);
        }

        /// <summary>
        /// Calls the API with a given sub URL
        /// </summary>
        /// <typeparam name="T">Return type of the API method to call. The resulting JSON gets parsed to the given type</typeparam>
        /// <param name="url">Sub url of the API method to call</param>
        /// <param name="urlSegments">
        /// The URL segments to replace. 
        /// .Key is the string in the URL to replace, .Value is the value to replace the segment with
        /// </param>
        /// <returns></returns>
        internal T CallAPI<T>(string url, IDictionary<string, string> urlSegments) where T : new()
        {
            var request = new RestRequest(url, Method.GET);
            foreach (var setting in urlSegments)
                request.AddUrlSegment(setting.Key, setting.Value);

            request.AddParameter("api_key", _apiKey);

            return _client.Execute<T>(request).Data;
        }

        /// <summary>
        /// Creates a new instance of the RiotGamesAPI class with the given API key
        /// </summary>
        /// <param name="apiKey"> 
        /// A value specifing the API key to use. Can either be:
        /// - a string directly containing the API key
        /// - a local file containing a single line of ASCII or Unicode symbols which should be treated as an API key
        /// - a freely accessible URL which answers a HTTP GET request with a valid API key
        /// </param>
        public RiotGamesAPI(string apiKey)
        {
            // detect key via KeyLoaderFactory

            _apiKey = ""; //KeyLoaderFactory.GetKey(apiKey);
        }
    }
}