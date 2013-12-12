using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechTex.RiotGamesAPI.Model
{
    public class Champion
    {
        /// <summary>
        /// Indicates if the champion is active.
        /// </summary>
        public bool Active { get; set; }
        
        /// <summary>
        /// Champion attack rank.
        /// </summary>
        public int AttackRank { get; set; }

        /// <summary>
        /// Bot enabled flag (for custom games).
        /// </summary>
        public bool BotEnabled { get; set; }

        /// <summary>
        /// Bot Match Made enabled flag (for Co-op vs. AI games).
        /// </summary>
        public bool BotMmEnabled { get; set; }

        /// <summary>
        /// Champion defense rank.
        /// </summary>
        public int DefenseRank { get; set; }

        /// <summary>
        /// Champion difficulty rank.
        /// </summary>
        public int DifficultyRank { get; set; }

        /// <summary>
        /// Indicates if the champion is free to play.
        /// Free to play champions are rotated periodically.
        /// </summary>
        public bool FreeToPlay { get; set; }
        
        /// <summary>
        /// Champion ID.
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Champion magic rank.
        /// </summary>
        public int MagicRank { get; set; }
        
        /// <summary>
        /// Champion name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ranked play enabled flag.
        /// </summary>
        public bool RankedPlayEnabled { get; set; }
    }
}
