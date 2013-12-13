using System;
using System.Collections.Generic;
using CsExtensions;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Cache.ChampionCache;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    internal enum CacheMethod
    {
        /// <summary>
        /// Default cache-method, storing the result once
        /// and using this one.
        /// </summary>
        Default,

        /// <summary>
        /// No cache-method at all. Results are no stored
        /// and requested ever again.
        /// </summary>
        NoCache
    }

    internal class CacheFactory
    {
        private const string CACHEMETHOD_NOTSUPORTED =
            "The requested cache-method '{0}' is not supported for this request.";

        private APICaller _apiCaller;

        private Dictionary<CacheMethod, AbstractCache<IList<Champion>>> _championCaches;
        private Dictionary<CacheMethod, AbstractCache<IList<RunePage>>> _runePageCaches;

        internal CacheFactory(string key)
        {
            initializeDictionaries();
            _apiCaller = new APICaller(key);
        }

        private void initializeDictionaries()
        {
            _championCaches = new Dictionary<CacheMethod, AbstractCache<IList<Champion>>>();
            _runePageCaches = new Dictionary<CacheMethod, AbstractCache<IList<RunePage>>>();
        }

        /* TODO | dj | \
         * an automatism for those cache-creations
         * would be very nice. :)
         */

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
            AbstractCache<IList<Champion>> acc;

            if (_championCaches.ContainsKey(cacheMethod))
                acc = _championCaches[cacheMethod];
            else
            {
                switch (cacheMethod)
                {
                    case CacheMethod.NoCache:
                        acc = new NoChampionCache(_apiCaller, region);
                        break;
                    case CacheMethod.Default:
                        acc = new DefaultChampionCache(_apiCaller, region);
                        break;
                    default:
                        throw new NotSupportedException(
                            CACHEMETHOD_NOTSUPORTED.Format(cacheMethod));
                }
                _championCaches.Add(cacheMethod, acc);
            }

            return acc.GetValue();
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
        internal IList<RunePage> GetRunePages(Regions region, int summonerId,
            CacheMethod cacheMethod = CacheMethod.Default)
        {
            AbstractCache<IList<RunePage>> acc;

            if (_runePageCaches.ContainsKey(cacheMethod))
                acc = _runePageCaches[cacheMethod];
            else
            {
                switch (cacheMethod)
                {
                    // TODO | dj | build those classes.
                    case CacheMethod.Default:
                        //break;
                    case CacheMethod.NoCache:
                        //break;
                    default:
                        throw new NotSupportedException(
                            CACHEMETHOD_NOTSUPORTED.Format(cacheMethod));
                }
            }

            return acc.GetValue();
        }
    }
}
