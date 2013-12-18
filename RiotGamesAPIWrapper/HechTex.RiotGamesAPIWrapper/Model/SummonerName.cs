using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model
{
    public class SummonerName
    {
        /* Kinda useless class, but mirrors API. */

        /// <summary>
        /// Summoner Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        public string Name { get; set; }
    }
}
