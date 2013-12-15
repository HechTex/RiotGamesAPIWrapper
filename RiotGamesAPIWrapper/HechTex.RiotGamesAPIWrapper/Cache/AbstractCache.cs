using HechTex.RiotGamesAPIWrapper.APIConstants;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    /// <summary>
    /// Abstract class to provide a universal interface
    /// of cache-classes.
    /// </summary>
    /// <typeparam name="T">The type of the data, the cache manages.</typeparam>
    internal abstract class AbstractCache<T>
    {
        /// <summary>
        /// The CacheMethod, the implementation uses.
        /// </summary>
        internal CacheMethod CacheMethod { get; set; }

        /// <summary>
        /// The region to query in.
        /// </summary>
        protected Regions Region { get; private set; }

        /// <summary>
        /// Optional parameter.
        /// </summary>
        protected string[] Parameters { get; private set; }

        /// <summary>
        /// The APICaller-instance, used for queries.
        /// </summary>
        protected APICaller ApiCaller { get; private set; }

        /// <summary>
        /// The method to be called on the ApiCaller.
        /// </summary>
        protected string MethodName { get; private set; } // TODO | dj | might be private.

        /// <summary>
        /// The base-constructor.<para/>
        /// Call this one, if inheriting the class.
        /// </summary>
        /// <param name="apiCaller">The APICaller-instance to be used for
        /// queries/calls to the API itself.</param>
        /// <param name="region">The region.</param>
        /// <param name="methodName">Name of method of apiCaller to be called.</param>
        /// <param name="parameters">Optional parameters, depending on</param>
        internal AbstractCache(APICaller apiCaller, Regions region,
            string methodName, params string[] parameters)
        {
            ApiCaller = apiCaller;
            MethodName = methodName;
            Region = region;
            Parameters = parameters;
        }

        /// <summary>
        /// Returns the value, the cache should provide.
        /// </summary>
        /// <returns></returns>
        internal abstract T GetValue();

        /// <summary>
        /// Calls the specified method.
        /// </summary>
        /// <returns>Returns the result of the method.</returns>
        protected T CallMethod()
        {
            var method = ApiCaller.GetType().GetMethod(MethodName);
            object[] pars;
            if (Parameters != null)
            {
                pars = new object[Parameters.Length + 1];
                pars[0] = Region;
                for (int i = 0; i < Parameters.Length; ++i)
                    pars[i + 1] = Parameters[i];
            }
            else
                pars = new object[] { Region };

            return (T)method.Invoke(ApiCaller, pars);
        }
    }
}
