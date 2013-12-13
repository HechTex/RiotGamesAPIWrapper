using System.Collections.Generic;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model;

namespace HechTex.RiotGamesAPIWrapper.Cache.ChampionCache
{
    /// <summary>
    /// Default cache-method for the ChampionCache.
    /// </summary>
    internal class DefaultChampionCache : AbstractCache<IList<Champion>>
    {
        private IList<Champion> _list;

        /// <summary>
        /// Constructor for the DefaultChampionCache.
        /// </summary>
        /// <param name="apiCaller">The APICaller-instance to be used for
        /// queries/calls to the API itself.</param>
        /// <param name="region">The region.</param>
        internal DefaultChampionCache(APICaller apiCaller, Regions region)
            : base(apiCaller, region)
        {
            CacheMethod = CacheMethod.Default;
        }

        internal override IList<Champion> GetValue()
        {
            if (_list == null || _list.Count == 0)
                _list = ApiCaller.GetChampions(Region);
            return _list;
        }
    }
}
