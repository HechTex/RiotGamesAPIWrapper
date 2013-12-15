using System.Collections.Generic;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod;
using HechTex.RiotGamesAPIWrapper.Model;

namespace HechTex.RiotGamesAPIWrapper.Cache.ChampionCache
{
    /// <summary>
    /// NoCache-method for ChampionCache
    /// </summary>
    internal class NoChampionCache : AbstractNoCache<IList<Champion>>
    {
        /// <summary>
        /// Constructor for the NoChampionCache.
        /// </summary>
        /// <param name="apiCaller">The APICaller-instance to be used for
        /// queries/calls to the API itself.</param>
        /// <param name="region">The region.</param>
        internal NoChampionCache(APICaller apiCaller, Regions region)
            : base(apiCaller, region, "GetChampions")
        {
            //CacheMethod = CacheMethod.NoCache;
        }

        //internal override IList<Champion> GetValue()
        //{
        //    return ApiCaller.GetChampions(Region);
        //}
    }
}
