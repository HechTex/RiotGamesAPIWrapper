using System;
using System.Collections.Generic;
using System.Linq;
using CsExtensions;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Masteries;
using HechTex.RiotGamesAPIWrapper.Model.Runes;
using RestSharp;

namespace HechTex.RiotGamesAPIWrapper
{
    internal class APICaller
    {
        // TODO upgrade api-versions!!!
        private const string API_BASE_URL = @"https://prod.api.pvp.net/";
        private const string API_URL_CHAMPIONS = @"api/lol/{region}/v1.1/champion"; // nearly deprecated
        private const string API_URL_RUNEPAGES = @"api/lol/{region}/v1.3/summoner/{summonerIds}/runes";
        private const string API_URL_MASTERYPAGES = @"api/lol/{region}/v1.3/summoner/{summonerIds}/masteries";
        private const string API_URL_SUMMONERNAMES = @"api/lol/{region}/v1.3/summoner/{summonerIds}/name";
        private const string API_URL_SUMMONERS = @"api/lol/{region}/v1.3/summoner/{summonerIds}";

        private RestClient _client;

        private string _apiKey;

        internal APICaller(string api_key)
        {
            _apiKey = api_key;
            _client = new RestClient(API_BASE_URL);
        }

        /// <summary>
        /// Returns the list of all champions.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <returns>List of Champions.</returns>
        internal IList<Champion> GetChampions(Regions region)
        {
            var urlsegs = new Dictionary<string, string> { { "region", GetRegionString(region) } }; // dat syntax
            return CallAPI<List<Champion>>(API_URL_CHAMPIONS, urlsegs, "champions");
        }

        /// <summary>
        /// Returns the list of runepages of the summoner(s).
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        /// <returns>List of RunePages.</returns>
        internal IList<RunePages> GetRunePages(Regions region, IEnumerable<long> summonerIds)
        {
            var urlsegs = new Dictionary<string, string> {
                { "region", GetRegionString(region) }, { "summonerIds", ",".Join(summonerIds) } };
            var res = CallAPI<Dictionary<string, RunePages>>(API_URL_RUNEPAGES, urlsegs, null);
            return GetValues(res);
        }

        /// <summary>
        /// Returns the list of masterypages of the summoner(s).
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        /// <returns>List of MasteryPages.</returns>
        internal IList<MasteryPages> GetMasteryPages(Regions region, IEnumerable<long> summonerIds)
        {
            var urlsegs = new Dictionary<string, string> {
                { "region", GetRegionString(region) }, { "summonerIds", ",".Join(summonerIds) } };
            var res = CallAPI<Dictionary<string, MasteryPages>>(API_URL_MASTERYPAGES, urlsegs, null);
            return GetValues(res);
        }

        /// <summary>
        /// Returns a list of the summonernames to the
        /// given ids.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        /// <returns>List of SummonerNames.</returns>
        internal IList<SummonerName> GetSummonerNames(Regions region, IEnumerable<long> summonerIds)
        {
            var urlsegs = new Dictionary<string, string> {
                { "region", GetRegionString(region) }, { "summonerIds", ",".Join(summonerIds) } };
            var res = CallAPI<Dictionary<string, string>>(API_URL_SUMMONERNAMES, urlsegs, null);
            return res.Select(pair => {
                var s = new SummonerName();
                s.Id = long.Parse(pair.Key);
                s.Name = pair.Value;
                return s;
            }).ToList<SummonerName>();
        }

        /// <summary>
        /// Returns a list of the requested summoners.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        /// <returns>List of Summoners.</returns>
        internal IList<Summoner> GetSummoners(Regions region, IEnumerable<long> summonerIds)
        {
            var urlsegs = new Dictionary<string, string> {
                { "region", GetRegionString(region) }, { "summonerIds", ",".Join(summonerIds) } };
            var res = CallAPI<Dictionary<string, Summoner>>(API_URL_SUMMONERS, urlsegs, null);
            return GetValues(res);
        }

        #region Helpmethods

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


        private string GetRegionString(Regions region)
        {
            return Enum.GetName(typeof(Regions), region).ToLower();
        }

        private IList<T> GetValues<T>(Dictionary<string, T> dict)
        {
            return dict.Select(pair => pair.Value).ToList();
        }

        #endregion
    }
}
