using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Masteries
{
    public class MasteryPages
    {
        /* again this class is pretty stupid but mirrors the API
         * we should discuss how we want to deserialize this.. */

        public int SummonerId { get; set; }
        public List<MasteryPage> Pages { get; set; }
    }
}