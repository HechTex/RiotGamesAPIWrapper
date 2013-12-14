using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Masteries
{
    public class MasteryPage
    {
        /// <summary>
        /// Mastery page name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates if the mastery page is the current mastery page.
        /// </summary>
        public bool Current { get; set; }

        /// <summary>
        /// List of mastery page talents associated with the mastery page.<para/>
        /// We continue to call those talents masteries.
        /// </summary>
        public List<Mastery> Talents { get; set; }  // see Mastery.cs, why this is called Talents
    }
}