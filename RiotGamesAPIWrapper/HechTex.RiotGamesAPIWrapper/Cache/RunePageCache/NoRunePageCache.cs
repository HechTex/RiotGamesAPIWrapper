using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache.RunePageCache
{
    /// <summary>
    /// NoCache-method for RunePageCache
    /// </summary>
    internal class NoRunePageCache : AbstractNoCache<IList<RunePage>>
    {
        /// <summary>
        /// Constructor for the NoRunePageCache.
        /// </summary>
        /// <param name="apiCaller">The APICaller-instance to be used for
        /// queries/calls to the API itself.</param>
        /// <param name="region">The region.</param>
        /// <param name="summonerId">The summoner's id.</param>
        internal NoRunePageCache(APICaller apiCaller, Regions region, long summonerId)
            : base(apiCaller, region, "GetRunePages", summonerId.ToString())
        {
            //CacheMethod = CacheMethod.NoCache;
        }

        //internal override IList<RunePage> GetValue()
        //{
        //    return ApiCaller.GetRunePages(Region, long.Parse(Parameters[0]));
        //}
    }
}
