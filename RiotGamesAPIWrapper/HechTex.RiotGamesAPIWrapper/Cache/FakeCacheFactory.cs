using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    /// <summary>
    /// A cache-factory, faking the cache. There is
    /// cache-method used at all. It uses APICaller
    /// directly.
    /// </summary>
    internal class FakeCacheFactory : AbstractCacheFactory
    {
        public FakeCacheFactory(string key, CacheSettings settings)
            : base(key, settings)
        { }

        /// <inheritdoc />
        internal override IList<Champion> GetChampions(Regions region)
        {
            return ApiCaller.GetChampions(region);
        }

        /// <inheritdoc />
        internal override IList<RunePage> GetRunePages(Regions region, long summonerId)
        {
            return ApiCaller.GetRunePages(region, summonerId);
        }

        /// <inheritdoc />
        internal override IList<SummonerName> GetSummonerNames(Regions region, IEnumerable<long> summonerIds)
        {
            return ApiCaller.GetSummonerNames(region, summonerIds);
        }
    }
}
