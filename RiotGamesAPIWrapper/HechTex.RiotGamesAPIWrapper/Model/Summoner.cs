using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model
{
    public class Summoner
    {
        /// <summary>
        /// Summoner id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Summoner name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id of the summoner icon associated with
        /// the summoner.
        /// </summary>
        public int ProfileIconId { get; set; }

        /// <summary>
        /// Date summoner was last modified specified
        /// as epoch milliseconds.
        /// </summary>
        public long RevisionDate { get; set; }  // TODO | dj | is it possible for JSON to use DateTime?

        /// <summary>
        /// Summoner level associated with the summoner.
        /// </summary>
        public long SummonerLevel { get; set; }
    }
}
