using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Runes
{
    public class RunePage
    {
        /// <summary>
        /// Rune page id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Rune page name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of rune slots associated with the rune page.
        /// </summary>
        public List<RuneSlot> Slots { get; set; }

        /// <summary>
        /// Indicates if the page is the current page.
        /// </summary>
        public bool Current { get; set; }
    }
}