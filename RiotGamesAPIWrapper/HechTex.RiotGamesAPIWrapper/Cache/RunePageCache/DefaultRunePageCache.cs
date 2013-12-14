using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache.RunePageCache
{
    /// <summary>
    /// Default cache-method for the RunePageCache.
    /// </summary>
    internal class DefaultRunePageCache : AbstractCache<IList<RunePage>>
    {
        private IList<RunePage> _list;

        /// <summary>
        /// Constructor for the DefaultRunePageCache.
        /// </summary>
        /// <param name="apiCaller">The APICaller-instance to be used for
        /// queries/calls to the API itself.</param>
        /// <param name="region">The region.</param>
        /// <param name="summonerId">The summoner's id.</param>
        internal DefaultRunePageCache(APICaller apiCaller, Regions region, long summonerId)
            : base(apiCaller, region, summonerId.ToString())
        {
            CacheMethod = CacheMethod.Default;
        }

        internal override IList<RunePage> GetValue()
        {
            if (_list == null || _list.Count == 0)
                _list = ApiCaller.GetRunePages(Region, int.Parse(Parameters[0]));
            return _list;
        }
    }
}
