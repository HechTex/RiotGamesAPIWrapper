using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Masteries;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    internal abstract class AbstractCacheFactory
    {
        internal APICaller ApiCaller { get; private set; }
        internal CacheSettings Settings { get; set; }

        internal AbstractCacheFactory(string key, CacheSettings settings)
        {
            ApiCaller = new APICaller(key);
            Settings = settings;
        }

        /// <summary>
        /// Returns the result of APICaller.GetChampions,
        /// filtered/provided by the chosen cache.
        /// </summary>
        /// <param name="region">The region.</param>
        abstract internal IList<Champion> GetChampions(Regions region);

        /// <summary>
        /// Returns the result of APICaller.GetRunePages,
        /// filtered/provided by the chosen cache.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        abstract internal IList<RunePages> GetRunePages(Regions region,
            IEnumerable<long> summonerIds);

        /// <summary>
        /// Returns the result of APICaller.GetMasteryPages,
        /// filtered/provided by the chosen cache.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        abstract internal IList<MasteryPages> GetMasteryPages(Regions region,
            IEnumerable<long> summonerIds);

        /// <summary>
        /// Returns the result of APICaller.GetSummonerNames,
        /// filtered/provided by the chosen cache.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        abstract internal IList<SummonerName> GetSummonerNames(Regions region,
            IEnumerable<long> summonerIds);

        /// <summary>
        /// Returns the result of APICaller.GetSummoners,
        /// filtered/provided by the chosen cache.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerIds">The summoner's ids.</param>
        /// <returns></returns>
        abstract internal IList<Summoner> GetSummoners(Regions region,
            IEnumerable<long> summonerIds);
    }
}
