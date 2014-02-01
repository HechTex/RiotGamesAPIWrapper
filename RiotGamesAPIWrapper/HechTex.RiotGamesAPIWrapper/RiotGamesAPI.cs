using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Cache;
using HechTex.RiotGamesAPIWrapper.KeyLoader;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

// Access for tests granted.
[assembly: InternalsVisibleTo("HechTex.Test")]

namespace HechTex.RiotGamesAPIWrapper
{
    /// <summary>
    /// Main access point to the HechTex.RiotGamesAPIWrapper library. 
    /// Needs to be supplied with a valid API key to correctly fetch results.
    /// </summary>
    public sealed class RiotGamesAPI
    {
        private const string DEFAULT_APIPATH = @"..\..\..\..\api.key";

        private AbstractCacheFactory _cacheFactory;

        /// <summary>
        /// Settings to be used for the requests.
        /// </summary>
        public CacheSettings CacheSettings { get; private set; }
        // TODO | dj | keep setter private or allow public change?

        // constructor is private to prevent misuse
        private RiotGamesAPI()
        { }

        /// <summary>
        /// Creates a new instance of the RiotGamesAPI class with the given API key
        /// </summary>
        /// <param name="apiKey"> 
        /// A value specifing the API key to use. Can either be:<para/>
        /// - a string directly containing the API key<para/>
        /// - a local file containing a single line of ASCII or Unicode symbols which should be treated as an API key<para/>
        /// - a freely accessible URL which answers a HTTP GET request with a valid API key
        /// </param>
        public RiotGamesAPI(string apiKey)
        {
            // detect key via KeyLoaderFactory
            if (String.IsNullOrEmpty(apiKey))
                apiKey = System.IO.Path.GetFullPath(DEFAULT_APIPATH);
            string key = KeyLoaderFactory.GetKey(apiKey); // TODO | dj | throws exceptions. (to be written in summary)

            CacheSettings = new CacheSettings();    // dj | if not using a reference, the updating would be to long-winded.
            
            // TODO | dj | Maybe here it could be possible to select the factory?
            //_cacheFactory = new FakeCacheFactory(key, CacheSettings);
            _cacheFactory = new TreeCacheFactory(key, CacheSettings);
        }

        /// <summary>
        /// Returns the list of all champions.
        /// Depending on cache-mode, this might take a moment.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <returns>List of Champions.<para/>
        /// Returns null, if no items/no connection.</returns>
        public IList<Champion> GetChampions(Regions region)
        {
            return _cacheFactory.GetChampions(region);
        }

        // TODO | dj | I want a method to get the Champion by ~name or at least id!

        /// <summary>
        /// Returns the list of all RunePages of the specified
        /// summoner. Depending on cache-mode, this might take
        /// a moment.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerIds">The summoner's ids for which
        /// to search.</param>
        /// <returns>List of RunePages.<para/>
        /// Returns null, if no items/no connection.</returns>
        public IList<RunePages> GetRunePages(Regions region, IEnumerable<long> summonerIds)
        {
            return _cacheFactory.GetRunePages(region, summonerIds);
        }

        /// <summary>
        /// Returns the summoner-names to the given ids.
        /// Depending on cache-mode, this might take a moment.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerIds">The summoner's ids for which
        /// the names will be fetched.</param>
        /// <returns>List of SummonerNames.<para/>
        /// Returns null, if no items/no connection.</returns>
        public IList<SummonerName> GetSummonerNames(Regions region,
            IEnumerable<long> summonerIds)
        {
            return _cacheFactory.GetSummonerNames(region, summonerIds);
        }

        /// <summary>
        /// Returns the summoners to the given ids.
        /// Depending on cache-mode, this might take a moment.
        /// </summary>
        /// <param name="region">Region to search in.</param>
        /// <param name="summonerIds">The summoner's ids for which
        /// to gather the information.</param>
        /// <returns>List of Summoners.<para />
        /// Returns null, if no items/no connection.</returns>
        public IList<Summoner> GetSummoners(Regions region,
            IEnumerable<long> summonerIds)
        {
            return _cacheFactory.GetSummoners(region, summonerIds);
        }
    }
}