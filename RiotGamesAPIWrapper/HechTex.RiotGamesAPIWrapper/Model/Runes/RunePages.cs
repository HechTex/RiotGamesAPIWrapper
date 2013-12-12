using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Runes
{
    public class RunePages
    {
        /* this is pretty stupid but mirrors the exact API response..
         * we should discuss how we want to deserialize this.. */

        public int SummonerId { get; set; }
        public List<RunePage> Pages { get; set; }
    }
}