using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace HechTex.RiotGamesAPIWrapper.APIConstants
{
    public enum MatchmakingQueues
    {
        Normal5v5Blind = 2
    }

    public enum Maps
    {
        SR              = 1,
        SR_Autumn       = 2,
        ProvingGrounds  = 3,
        TT_original     = 4,
        CrystalScar     = 8,
        TT              = 10,
        HowlingAbyss    = 12
    }

    public enum GameTypes
    {
        CUSTOM_GAME = 0,
        ODIN        = 1,
        ARAM        = 2,
        TURORIAL    = 3
    }
}