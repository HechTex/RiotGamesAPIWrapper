using System;

// ReSharper disable once CheckNamespace
namespace HechTex.RiotGamesAPIWrapper.APIConstants
{
    [Obsolete]
    public enum MatchmakingQueues // TODO | dj | they seem to be gone/replaced by subtypes
    {
        Normal5v5Blind          = 2,
        RankedSolo5v5           = 4,
        CoopVsAI5v5             = 7,
        Normal3v3               = 8,
        Normal5v5Draft          = 14,
        Dominion5v5Blind        = 16,
        Dominion5v5Draft        = 17,
        DominionCoopVsAI        = 25,
        RankedTeam3v3           = 41,
        RankedTeam5v5           = 42,
        TwistedTreelineCoopVsAI = 52,
        ARAM                    = 65,
        ARAMCoopVsAI            = 67
    }

    public enum SubTypes
    {
        NONE                    = 0,
        NORMAL                  = 1,
        NORMAL_3x3              = 2,
        ODIN_UNRANKED           = 3,
        ARAM_UNRANKED_5x5       = 4,
        BOT                     = 6,
        BOT_3x3                 = 7,
        RANKED_SOLO_5x5         = 8,
        RANKED_TEAM_3x3         = 9,
        RANKED_TEAM_5x5         = 10,
        ONEFORALL_5x5           = 11,
        FIRSTBLOOD_1x1          = 12,
        FIRSTBLOOD_2x2          = 13
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

    public enum GameModes
    {
        CLASSIC     = 0,
        ODIN        = 1,
        ARAM        = 2,
        TURORIAL    = 3,
        ONEFORALL   = 4,
        FIRSTBLOOD  = 5
    }

    public enum GameTypes
    {
        CUSTOM_GAME     = 0,
        TUTORIAL_GAME   = 1,
        MATCHED_GAME    = 2
    }

    public enum Regions
    {
        /// Use with Enum.getName(...).ToLower() for requests.
        BR      = 0,
        EUNE    = 1,
        EUW     = 2,
        NA      = 3,
        TR      = 4,
        KR      = 5,
        LAN     = 6,
        OCE     = 7,
        RU      = 8
    }
}