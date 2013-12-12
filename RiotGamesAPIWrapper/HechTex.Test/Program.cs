using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsExtensions.Console;
using CsExtensions;
using HechTex.RiotGamesAPIWrapper;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.KeyLoader;
using HechTex.RiotGamesAPIWrapper.Model;

namespace HechTex.Test
{
    class Program
    {
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
            var result = api.GetRunePages(Regions.EUW, 26231463);
            Console.WriteLine("Runepages:");
            foreach (var page in result)
                Console.WriteLine(page.GetInfoString());
        }
    }
}
