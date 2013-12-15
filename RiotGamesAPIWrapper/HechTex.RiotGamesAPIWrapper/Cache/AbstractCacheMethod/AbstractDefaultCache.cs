using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;

namespace HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod
{
    internal class AbstractDefaultCache<T> : AbstractCache<T>
    {
        private T _content;

        internal AbstractDefaultCache(APICaller apiCaller, Regions region,
            string methodName, params string[] parameters)
            : base(apiCaller, region, methodName, parameters)
        {
            CacheMethod = CacheMethod.Default;
        }

        internal override T GetValue()
        {
            if (_content == null)
                _content = CallMethod();
            return _content;
        }
    }
}
