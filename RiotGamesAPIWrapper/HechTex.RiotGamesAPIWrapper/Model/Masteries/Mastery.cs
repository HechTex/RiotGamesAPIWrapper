using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Masteries
{
    public class Mastery    
    {
        /* the actual "class" the API mentions is called "Talent"
         * but this should not be an issue, since its just JSON */

        /// <summary>
        /// Mastery/Talent id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Mastery/Talent name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Mastery/Talent rank.
        /// </summary>
        public int Rank { get; set; }
    }
}