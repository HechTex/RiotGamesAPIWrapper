using System;
using CsExtensions;
using CsExtensions.Console;
using HechTex.RiotGamesAPIWrapper;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Cache;
using HechTex.RiotGamesAPIWrapper.KeyLoader;

namespace HechTex.Test
{
    class Program
    {
        private const long SUMMONERID = 26231463;
        private const long SUMMONERID2 = 20051790;

        static void Main(string[] args)
        {
            DynamicTestConsole.Start<Program>();
        }

        [DynamicTestConsole.Comment("Simple test for own key.")]
        public static void TestKeyLoaderFactory()
        {
            Console.WriteLine("Put in your API-Key or the filepath:");
            string input = Console.ReadLine();
            
            try {
                string output = KeyLoaderFactory.GetKey(input);
                Console.WriteLine("Analyzed key: {0}", output);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        [DynamicTestConsole.Comment("Test to get all champions.")]
        public static void TestGetAllChampions()
        {
            RiotGamesAPI api = new RiotGamesAPI(null);
            var result = api.GetChampions(Regions.EUW);
            Console.WriteLine("Champions:");
            foreach (var champ in result)
                Console.WriteLine(champ.GetInfoString());
        }

        [DynamicTestConsole.Comment("Test to get rune pages of a summoner.")]
        public static void TestGetRunePages()
        {
            RiotGamesAPI api = new RiotGamesAPI(null);
            var result = api.GetRunePages(Regions.EUW, new long[] { SUMMONERID, SUMMONERID2 });
            Console.WriteLine("Runepages:");
            foreach (var page in result)
                Console.WriteLine(page.GetInfoString());
        }

        [DynamicTestConsole.Comment("Test to get mastery pages of a summoner.")]
        public static void TestGetMasteryPages()
        {
            RiotGamesAPI api = new RiotGamesAPI(null);
            var result = api.GetMasteryPages(Regions.EUW, new long[] { SUMMONERID, SUMMONERID2 });
            Console.WriteLine("Masterypages:");
            foreach (var page in result)
                Console.WriteLine(page.GetInfoString());
        }

        [DynamicTestConsole.Comment("Test to get summoner-names from ids.")]
        public static void TestGetSummonerNames()
        {
            RiotGamesAPI api = new RiotGamesAPI(null);
            var result = api.GetSummonerNames(Regions.EUW,
                new long[] { SUMMONERID, SUMMONERID2 });
            Console.WriteLine("Summonernames:");
            foreach (var name in result)
                Console.WriteLine(name.GetInfoString());
        }

        [DynamicTestConsole.Comment("Test to get summoners by ids.")]
        public static void TestGetSummoners()
        {
            RiotGamesAPI api = new RiotGamesAPI(null);
            var result = api.GetSummoners(Regions.EUW,
                new long[] { SUMMONERID, SUMMONERID2 });
            Console.WriteLine("Summoners:");
            foreach (var name in result)
                Console.WriteLine(name.GetInfoString());
        }

        [Obsolete]
        [DynamicTestConsole.Comment("Testing the TimedCache. CONSUMES: time, response")]
        public static void TestTimedCache()
        {
            CacheSettings cs = new CacheSettings()
            {
                GetChampions = CacheMethod.TimedCache,
                GetRunePages = CacheMethod.TimedCache,
                GetSummonerNames = CacheMethod.TimedCache
            };

            MultipleCacheFactory cf = new MultipleCacheFactory(KeyLoaderFactory.GetKey(
                System.IO.Path.GetFullPath(@"..\..\..\..\api.key")), cs);
            Console.WriteLine("You might want to use breakpoints for verification.");

            // TODO | dj | use PerformanceCounter to observe network.
            Console.WriteLine("Got {0} champions with a total {1} Bytes received.".Format(
                cf.GetChampions(Regions.EUW).Count));
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 50));
            Console.WriteLine("Got {0} champions after 50 seconds".Format(
                cf.GetChampions(Regions.EUW).Count));
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 50));
            Console.WriteLine("Got {0} champions after +50 seconds".Format(
                cf.GetChampions(Regions.EUW).Count));

        }
    }
}
