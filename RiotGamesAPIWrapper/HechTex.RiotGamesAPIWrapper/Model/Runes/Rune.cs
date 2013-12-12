using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPIWrapper.Model.Runes
{
    public class Rune
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
        public string Description { get; set; }
    }
}