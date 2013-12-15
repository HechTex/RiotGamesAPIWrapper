using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// No cache-method at all. Results are not stored
        /// and requested always again.
        /// </summary>
        NoCache
    }

}
