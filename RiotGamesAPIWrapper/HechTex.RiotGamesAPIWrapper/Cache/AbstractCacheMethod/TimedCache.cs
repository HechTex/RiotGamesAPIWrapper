using System;

namespace HechTex.RiotGamesAPIWrapper.Cache.AbstractCacheMethod
{
    /// <summary>
    /// Implementation of TimedCache.<para/>
    /// Stores the data and only updates it, if
    /// the timespan to the last update is great
    /// enough.
    /// </summary>
    internal class TimedCache<T> : AbstractCache<T>
    {
        // TODO | dj | adjust minimum offset?
        private static readonly TimeSpan MIN_OFFSET = new TimeSpan(0, 1, 0); // once a minute.

        private T _content;
        private DateTime _lastUpdate;

        internal TimedCache(Func<T> function)
            : base(function)
        {
            CacheMethod = CacheMethod.TimedCache;
        }

        internal override T GetValue()
        {
            if (_content == null ||
                DateTime.Now.Subtract(MIN_OFFSET).CompareTo(_lastUpdate) > 0)
            {
                _content = Function();
                _lastUpdate = DateTime.Now;
            }
            return _content;
        }
    }
}
