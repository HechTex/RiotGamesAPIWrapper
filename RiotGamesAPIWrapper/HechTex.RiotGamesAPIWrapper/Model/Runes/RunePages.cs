using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Runes
{
    public class RunePages
    {
        /// <summary>
        /// Summoner id.
        /// </summary>
        public long SummonerId { get; set; }

        /// <summary>
        /// Set of rune pages associated with
        /// the summoner.
        /// </summary>
        public List<RunePage> pages { get; set; }
    }
}
