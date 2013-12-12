using System;
using System.Collections.Generic;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.KeyLoader;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Runes;
using RestSharp;

namespace HechTex.RiotGamesAPIWrapper
{
    /// <summary>
    /// Main access point to the HechTex.RiotGamesAPIWrapper library. 
    /// Needs to be supplied with a valid API key to correctly fetch results.
    /// </summary>
    public sealed class RiotGamesAPI
    {
        private const string DEFAULT_APIPATH = @"..\..\..\..\api.key";

        private const string API_BASE_URL = @"https://prod.api.pvp.net/";
        private const string API_URL_CHAMPION = @"api/lol/{region}/v1.1/champion";
        private const string API_URL_RUNEPAGES = @"api/lol/{region}/v1.1/summoner/{summonerId}/runes";

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
        /// <param name="rootelement">Rootelement at which the deserialization starts.</param>
        /// <returns></returns>
        internal T CallAPI<T>(string url, IDictionary<string, string> urlSegments,
            string rootelement) where T : new()
        {
            var request = new RestRequest(url, Method.GET) { RootElement = rootelement };
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
        public RiotGamesAPI(string apiKey) : this()
        {
            // detect key via KeyLoaderFactory
            if (String.IsNullOrEmpty(apiKey))
                apiKey = System.IO.Path.GetFullPath(DEFAULT_APIPATH);
            _apiKey = KeyLoaderFactory.GetKey(apiKey); // TODO | dj | throws exceptions. (to be written in summary)
        }

        /// <summary>
        /// Returns the list of all champions.
        /// Depending on cache-mode, this might take a moment.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <returns>List of Champions.</returns>
        public IList<Champion> GetChampions(Regions region)
        {
            var urlsegs = new Dictionary<string, string> {{"region", GetRegionString(region)}}; // dat syntax
            // TODO | dj | use Cache here!!!
            return CallAPI<List<Champion>>(API_URL_CHAMPION, urlsegs, "champions");
        }

        /// <summary>
        /// Returns the list of runepages of a summoner.
        /// Depending on cache-mode, this might take a moment.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerId">The summoner's id.</param>
        /// <returns>List of RunePages.</returns>
        public IList<RunePage> GetRunePages(Regions region, int summonerId)
        {
            var urlsegs = new Dictionary<string, string> {
                { "region", GetRegionString(region) }, { "summonerId", summonerId.ToString() } };
            // with this, no RunePages-class is needed.
            return CallAPI<List<RunePage>>(API_URL_RUNEPAGES, urlsegs, "pages");
        }

        // TODO | dj | I want a method to get the Champion by ~name or at least id!

        private string GetRegionString(Regions region)
        {
            return Enum.GetName(typeof(Regions), region).ToLower();
        }
    }
}