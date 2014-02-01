// ReSharper disable once CheckNamespace
namespace HechTex.RiotGamesAPIWrapper.APIConstants
{
    public enum MatchmakingQueues
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