using System;
using HechTex.RiotGamesAPIWrapper.APIConstants;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    /// <summary>
    /// Abstract class to provide a universal interface
    /// of cache-classes.
    /// </summary>
    /// <typeparam name="T">The type of the data, the cache manages.
    /// </typeparam>
    internal abstract class AbstractCache<T>
    {
        /// <summary>
        /// The CacheMethod, the implementation uses.
        /// </summary>
        internal CacheMethod CacheMethod { get; set; }

        /// <summary>
        /// The method to be called on the ApiCaller.
        /// </summary>
        protected Func<T> Function { get; set; }

        /// <summary>
        /// The base-constructor.<para/>
        /// Call this one, if inheriting the class.
        /// </summary>
        /// <param name="function">Method to be called.</param>
        internal AbstractCache(Func<T> function)
        {
            Function = function;
        }

        /// <summary>
        /// Returns the value, the cache should provide.
        /// </summary>
        /// <returns></returns>
        internal abstract T GetValue();

    }
}
