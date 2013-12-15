using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;

namespace HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod
{
    internal class AbstractNoCache<T> : AbstractCache<T>
    {
        internal AbstractNoCache(APICaller apiCaller, Regions region,
            string methodName, params string[] parameters)
            : base(apiCaller, region, methodName, parameters)
        {
            CacheMethod = CacheMethod.NoCache;
        }

        internal override T GetValue()
        {
            return CallMethod();
        }
    }
}
