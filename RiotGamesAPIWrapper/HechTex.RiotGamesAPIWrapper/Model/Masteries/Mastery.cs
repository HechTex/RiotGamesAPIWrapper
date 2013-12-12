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

        public int Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
    }
}