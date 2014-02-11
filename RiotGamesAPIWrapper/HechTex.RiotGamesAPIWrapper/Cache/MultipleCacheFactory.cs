using System;
using System.Collections.Generic;
using CsExtensions;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Masteries;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    /// <summary>
    /// A cache-factory, trying to provide different cache-methods.
    /// Unfortunately it works only with NoCache. The other CacheMethods
    /// are properly working only for the exact same parameters.
    /// </summary>
    internal class MultipleCacheFactory : AbstractCacheFactory
    {
        private const string CACHEMETHOD_NOTSUPPORTED =
            "The requested cache-method '{0}' is not supported for this request.";

        private Dictionary<CacheMethod, AbstractCache<IList<Champion>>> _championCaches;
        private Dictionary<CacheMethod, AbstractCache<IList<RunePages>>> _runePageCaches;
        private Dictionary<CacheMethod, AbstractCache<IList<SummonerName>>> _summonerNamesCaches;

        internal MultipleCacheFactory(string key, CacheSettings settings)
            : base(key, settings)
        {
            InitializeDictionaries();
        }

        private void InitializeDictionaries()
        {
            _championCaches = new Dictionary<CacheMethod, AbstractCache<IList<Champion>>>();
            _runePageCaches = new Dictionary<CacheMethod, AbstractCache<IList<RunePages>>>();
            _summonerNamesCaches = new Dictionary<CacheMethod,AbstractCache<IList<SummonerName>>>();
        }

        internal override IList<Champion> GetChampions(Regions region)
        {
            return CallCache<IList<Champion>>(_championCaches,
                () => ApiCaller.GetChampions(region), Settings.GetChampions);
        }

        internal override IList<RunePages> GetRunePages(Regions region, IEnumerable<long> summonerId)
        {
            return CallCache<IList<RunePages>>(_runePageCaches,
                () => ApiCaller.GetRunePages(region, summonerId),
                Settings.GetRunePages);
        }

        internal override IList<MasteryPages> GetMasteryPages(Regions region, IEnumerable<long> summonerIds)
        {
            // TODO implement!
            throw new NotImplementedException();
        }

        internal override IList<SummonerName> GetSummonerNames(Regions region,
            IEnumerable<long> summonerIds)
        {
            return CallCache<IList<SummonerName>>(_summonerNamesCaches,
                () => ApiCaller.GetSummonerNames(region, summonerIds),
                Settings.GetSummonerNames);
        }

        internal override IList<Summoner> GetSummoners(Regions region, IEnumerable<long> summonerIds)
        {
            // TODO implement!
            throw new NotImplementedException();
        }

        #region Helpmethods

        /// <summary>
        /// One method to rule 'em all!
        /// </summary>
        /// <typeparam name="T">Desired returnvalue.</typeparam>
        /// <param name="cacheDict">The dictionary of caches to look
        /// and/or store in.</param>
        /// <param name="func">The function to be called
        /// (e.g. () => _apiCaller.GetChampions(region)).</param>
        /// <param name="cacheMethod">The CacheMethod to use.</param>
        /// <returns>The result of func from the corresponding cache.</returns>
        private T CallCache<T>(Dictionary<CacheMethod, AbstractCache<T>> cacheDict,
             Func<T> func, CacheMethod cacheMethod = CacheMethod.Default)
        {
            AbstractCache<T> ac;

            if (cacheDict.ContainsKey(cacheMethod))
                ac = cacheDict[cacheMethod];
            else
            {
                switch (cacheMethod)
                {
                    // TODO more cache-implementations are going here!
                    case CacheMethod.Default:
                        ac = new DefaultCache<T>(func);
                        break;
                    case CacheMethod.NoCache:
                        ac = new NoCache<T>(func);
                        break;
                    case CacheMethod.TimedCache:
                        ac = new TimedCache<T>(func);
                        break;
                    default:
                        throw new NotSupportedException(
                            CACHEMETHOD_NOTSUPPORTED.Format(cacheMethod));
                }
                cacheDict.Add(cacheMethod, ac);
            }

            return ac.GetValue();
        }

        #endregion
    }
}
