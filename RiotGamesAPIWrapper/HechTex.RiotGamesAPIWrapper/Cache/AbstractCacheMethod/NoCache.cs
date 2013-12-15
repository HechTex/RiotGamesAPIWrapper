using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;

namespace HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod
{
    /// <summary>
    /// Implementation of NoCache.<para/>
    /// Every call requests the data again from
    /// remote. No storage at all.
    /// </summary>
    internal class NoCache<T> : AbstractCache<T>
    {
        internal NoCache(Func<T> function)
            : base(function)
        {
            CacheMethod = CacheMethod.NoCache;
        }

        internal override T GetValue()
        {
            return Function();
        }
    }
}
