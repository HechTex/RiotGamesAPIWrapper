
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
        NoCache,

        /// <summary>
        /// Timed cache-method, only updating data after a
        /// timespan from last the request.
        /// </summary>
        TimedCache

        /* ===== IMPORTANT ============================= *
         * Any new CacheMethod has to be implemented and *
         * added to the CacheFactory.CallCache-method!   *
         * ============================================= */
    }

}
