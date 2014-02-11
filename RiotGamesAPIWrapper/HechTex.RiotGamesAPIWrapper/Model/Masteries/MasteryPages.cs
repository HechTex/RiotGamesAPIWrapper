using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Masteries
{
    public class MasteryPages
    {
        /// <summary>
        /// Collection of mastery pages associated
        /// with the summoner.
        /// </summary>
        public List<MasteryPage> Pages { get; set; }

        /// <summary>
        /// Summoner ID.
        /// </summary>
        public long SummonerId { get; set; }
    }
}
