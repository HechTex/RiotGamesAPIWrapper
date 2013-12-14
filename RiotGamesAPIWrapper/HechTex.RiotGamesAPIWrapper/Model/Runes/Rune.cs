using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Runes
{
    public class Rune
    {
        /// <summary>
        /// Rune id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Rune name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Rune tier.
        /// </summary>
        public int Tier { get; set; }

        /// <summary>
        /// Rune description.
        /// </summary>
        public string Description { get; set; }
    }
}