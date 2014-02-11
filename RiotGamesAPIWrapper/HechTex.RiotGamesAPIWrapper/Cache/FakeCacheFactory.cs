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
    /// <summary>
    /// A cache-factory, faking the cache. There is
    /// no cache-method used at all.
    /// It uses APICaller directly.
    /// </summary>
    internal class FakeCacheFactory : AbstractCacheFactory
    {
        public FakeCacheFactory(string key, CacheSettings settings)
            : base(key, settings)
        { }

        internal override IList<Champion> GetChampions(Regions region)
        {
            return ApiCaller.GetChampions(region);
        }

        internal override IList<RunePages> GetRunePages(Regions region, IEnumerable<long> summonerIds)
        {
            return ApiCaller.GetRunePages(region, summonerIds);
        }

        internal override IList<MasteryPages> GetMasteryPages(Regions region, IEnumerable<long> summonerIds)
        {
            return ApiCaller.GetMasteryPages(region, summonerIds);
        }

        internal override IList<SummonerName> GetSummonerNames(Regions region, IEnumerable<long> summonerIds)
        {
            return ApiCaller.GetSummonerNames(region, summonerIds);
        }

        internal override IList<Summoner> GetSummoners(Regions region, IEnumerable<long> summonerIds)
        {
            return ApiCaller.GetSummoners(region, summonerIds);
        }
    }
}
