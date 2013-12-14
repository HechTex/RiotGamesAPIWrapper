using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Runes
{
    public class RuneSlot
    {
        /// <summary>
        /// Rune slot id.
        /// </summary>
        public int RuneSlotId { get; set; }

        /// <summary>
        /// Rune associated with the rune slot.
        /// </summary>
        public Rune Rune { get; set; }
    }
}