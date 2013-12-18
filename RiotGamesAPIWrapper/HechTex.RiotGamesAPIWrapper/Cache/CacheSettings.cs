using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    /// <summary>
    /// Container class to provide easy control
    /// over the chosen CacheMethods.
    /// </summary>
    public class CacheSettings
    {
        /// <summary>
        /// CacheMethod for the GetChampions-request.
        /// </summary>
        public CacheMethod GetChampions { get; set; }

        /// <summary>
        /// CacheMethod for the GetRunePages-request.
        /// </summary>
        public CacheMethod GetRunePages { get; set; }

        /// <summary>
        /// CacheMethod for the GetSummonerNames-request.
        /// </summary>
        public CacheMethod GetSummonerNames { get; set; }

        /* ===== NOTE ============================= *
         * Every new method in RiotGamesAPI calling *
         * a cache should get a corresponding prop- *
         * erty in this class.                      *
         * ======================================== */
    }
}
