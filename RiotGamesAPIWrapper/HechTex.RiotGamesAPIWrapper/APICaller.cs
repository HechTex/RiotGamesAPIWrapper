using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Runes;
using RestSharp;

namespace HechTex.RiotGamesAPIWrapper
{
    internal class APICaller
    {
        private const string API_BASE_URL = @"https://prod.api.pvp.net/";
        private const string API_URL_CHAMPION = @"api/lol/{region}/v1.1/champion";
        private const string API_URL_RUNEPAGES = @"api/lol/{region}/v1.1/summoner/{summonerId}/runes";

        private RestClient _client;

        private string _apiKey;

        internal APICaller(string api_key)
        {
            _apiKey = api_key;
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
        /// <param name="rootElement">Rootelement at which the deserialization starts.</param>
        /// <returns></returns>
        private T CallAPI<T>(string url, IDictionary<string, string> urlSegments,
            string rootElement) where T : new()
        {
            var request = new RestRequest(url, Method.GET) { RootElement = rootElement };
            foreach (var setting in urlSegments)
                request.AddUrlSegment(setting.Key, setting.Value);

            request.AddParameter("api_key", _apiKey);
            return _client.Execute<T>(request).Data;
        }

        /// <summary>
        /// Returns the list of all champions.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <returns>List of Champions.</returns>
        internal IList<Champion> GetChampions(Regions region)
        {
            var urlsegs = new Dictionary<string, string> { { "region", GetRegionString(region) } }; // dat syntax
            return CallAPI<List<Champion>>(API_URL_CHAMPION, urlsegs, "champions");
        }

        /// <summary>
        /// Returns the list of runepages of a summoner.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerId">The summoner's id.</param>
        /// <returns>List of RunePages.</returns>
        internal IList<RunePage> GetRunePages(Regions region, int summonerId)
        {
            var urlsegs = new Dictionary<string, string> {
                { "region", GetRegionString(region) }, { "summonerId", summonerId.ToString() } };
            // with this, no RunePages-class is needed.
            return CallAPI<List<RunePage>>(API_URL_RUNEPAGES, urlsegs, "pages");
        }

        #region Helpmethods

        private string GetRegionString(Regions region)
        {
            return Enum.GetName(typeof(Regions), region).ToLower();
        }

        #endregion
    }
}
