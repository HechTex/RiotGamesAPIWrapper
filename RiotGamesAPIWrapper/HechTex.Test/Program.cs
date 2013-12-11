using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsExtensions.Console;
using HechTex.RiotGamesAPI.KeyLoader;

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
    }
}
