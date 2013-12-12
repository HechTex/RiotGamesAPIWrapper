using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Masteries
{
    public class MasteryPage
    {
        public string Name { get; set; }
        public bool Current { get; set; }
        public List<Mastery> Talents { get; set; }  // see Mastery.cs, why this is called Talents
    }
}