using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HechTex.RiotGamesAPIWrapper.APIConstants;

namespace HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod
{
    /// <summary>
    /// Implementation of DefaultCache.<para/>
    /// Simple implementation by storing the
    /// requested data once and for this session.
    /// </summary>
    internal class DefaultCache<T> : AbstractCache<T>
    {
        private T _content;

        internal DefaultCache(Func<T> function)
            : base(function)
        {
            CacheMethod = CacheMethod.Default;
        }

        internal override T GetValue()
        {
            if (_content == null)
                _content = Function();
            return _content;
        }
    }
}
