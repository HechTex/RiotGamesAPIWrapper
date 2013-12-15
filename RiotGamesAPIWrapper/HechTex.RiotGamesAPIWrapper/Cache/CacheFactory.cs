using System;
using System.Collections.Generic;
using CsExtensions;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    internal class CacheFactory
    {
        private const string CACHEMETHOD_NOTSUPORTED =
            "The requested cache-method '{0}' is not supported for this request.";

        private APICaller _apiCaller;

        private Dictionary<CacheMethod, AbstractCache<IList<Champion>>> _championCaches;
        private Dictionary<CacheMethod, AbstractCache<IList<RunePage>>> _runePageCaches;

        internal CacheFactory(string key)
        {
            InitializeDictionaries();
            _apiCaller = new APICaller(key);
        }

        private void InitializeDictionaries()
        {
            _championCaches = new Dictionary<CacheMethod, AbstractCache<IList<Champion>>>();
            _runePageCaches = new Dictionary<CacheMethod, AbstractCache<IList<RunePage>>>();
        }

        /// <summary>
        /// Returns the result of APICaller.GetChampions,
        /// filtered/provided by the chosen cache.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="cacheMethod">The CacheMethod.<para/>
        /// Not every Method might be implemented for this kind of
        /// request. Please keep this in mind.</param>
        /// <returns>List of all champions.</returns>
        // TODO | dj | Not implemented cache-methods shouldn't exist!
        internal IList<Champion> GetChampions(Regions region,
            CacheMethod cacheMethod = CacheMethod.Default)
        {
            return CallCache<IList<Champion>>(_championCaches,
                () => _apiCaller.GetChampions(region), cacheMethod);
        }

        /// <summary>
        /// Returns the result of APICaller.GetRunePages,
        /// filtered/provided by the chosen cache.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="summonerId">The summoner's id.</param>
        /// <param name="cacheMethod">The CacheMethod.<para/>
        /// Not every Method might be implemented for this kind of
        /// request. Please keep this in mind.</param>
        /// <returns>List of all champions.</returns>
        // TODO | dj | Not implemented cache-methods shouldn't exist!
        internal IList<RunePage> GetRunePages(Regions region, long summonerId,
            CacheMethod cacheMethod = CacheMethod.Default)
        {
            return CallCache<IList<RunePage>>(_runePageCaches,
                () => _apiCaller.GetRunePages(region, summonerId), cacheMethod);
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
                    default:
                        throw new NotSupportedException(
                            CACHEMETHOD_NOTSUPORTED.Format(cacheMethod));
                }
                cacheDict.Add(cacheMethod, ac);
            }

            return ac.GetValue();
        }

        #endregion
    }
}
