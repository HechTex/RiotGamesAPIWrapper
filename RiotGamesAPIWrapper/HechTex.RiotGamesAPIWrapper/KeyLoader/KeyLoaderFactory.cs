using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HechTex.RiotGamesAPIWrapper.KeyLoader
{
    /// <summary>
    /// Factory class to get the API-Key from an input.
    /// <para />
    /// Discussable, whether this has to be a 'factory'.
    /// </summary>
    internal class KeyLoaderFactory
    {
        // TODO VERIFY!
        private readonly static Regex API_PATTERN = new Regex(@"[\da-z]{8}(?:-[\da-z]{4}){3}-[\da-z]{12}",
                                                            RegexOptions.Compiled);

        /// <summary>
        /// Filters the key from the input. This might
        /// be the key itself or a filename.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The key as a string.</returns>
        internal static string GetKey(string input)
        {
            if (API_PATTERN.IsMatch(input))
                return FromKey(input);

            // TODO already throw Exception if input no key and no uri!

            Uri u = new Uri(input);
            // TODO if (!u.IsAbsoluteUri) throw Exception("NOPE");
            //      or convert with System.Path to Absolute?!
            if (u.IsFile)
                return FromLocalFile(input);
            
            // if it's not a local file it must be a remote
            return FromRemote(u);
        }

        private static string FromKey(string input)
        {
            return API_PATTERN.Match(input).Value;
        }

        private static string FromLocalFile(string input)
        {
            foreach (string line in File.ReadLines(input))
                if (API_PATTERN.IsMatch(line))
                    return FromKey(line);
            throw new KeyLoadingException("Invalid key-file. No API-Key found!",
                            input);
        }

        private static string FromRemote(Uri input)
        {
            throw new NotImplementedException("");
        }
    }

    public class KeyLoadingException : Exception
    {
        /// <summary>
        /// Input, got from caller.
        /// </summary>
        public string InputLine { get; private set; }

        public KeyLoadingException(string exceptionstring, string input)
            : base(exceptionstring)
        {
            InputLine = input;
        }
    }
}