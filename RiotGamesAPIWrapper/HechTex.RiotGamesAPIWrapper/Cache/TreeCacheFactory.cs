using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsExtensions.Constructs.Tree;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model;
using HechTex.RiotGamesAPIWrapper.Model.Masteries;
using HechTex.RiotGamesAPIWrapper.Model.Runes;

namespace HechTex.RiotGamesAPIWrapper.Cache
{
    /// <summary>
    /// A rather complex factory, using hash-trees
    /// to store the results.
    /// </summary>
    internal class TreeCacheFactory : AbstractCacheFactory
    {
        /* TODO:
         * [x] storing
         * [ ] automatic clearing (put a timestamp onto it)
         * [ ] maybe forced clear possible
         */

        private Dictionary<Regions, IList<Champion>> _champions;
        private IMultipleKeysTree<string, RunePages> _runePages;
        private IMultipleKeysTree<string, MasteryPages> _masteryPages;
        private IMultipleKeysTree<string, Summoner> _summoners;
        private IMultipleKeysTree<string, SummonerName> _summonerNames;

        internal TreeCacheFactory(string key, CacheSettings settings)
            : base(key, settings)
        {
            InitializeHashContainer();
        }

        private void InitializeHashContainer()
        {
            _champions = new Dictionary<Regions, IList<Champion>>();
            _runePages = new MultipleHashTree<string, RunePages>();
            _masteryPages = new MultipleHashTree<string, MasteryPages>();
            _summoners = new MultipleHashTree<string, Summoner>();
            _summonerNames = new MultipleHashTree<string, SummonerName>();
        }

        internal override IList<Champion> GetChampions(Regions region)
        {
            if (!_champions.ContainsKey(region))
                _champions.Add(region, ApiCaller.GetChampions(region));

            return _champions[region];
        }

        internal override IList<RunePages> GetRunePages(
            Regions region, IEnumerable<long> summonerIds)
        {
            IList<RunePages> pages = new List<RunePages>();
            List<long> toBeFetched = new List<long>();
            string reg = region.ToString();
            
            foreach (long id in summonerIds)
                if (!_runePages.Contains(reg, id.ToString()))
                    toBeFetched.Add(id);

            foreach (RunePages item in ApiCaller.GetRunePages(region, toBeFetched))
                _runePages.Add(item, reg, item.SummonerId.ToString());

            foreach (long id in summonerIds)
                pages.Add(_runePages[reg, id.ToString()]);

            return pages;
        }

        internal override IList<MasteryPages> GetMasteryPages(Regions region, IEnumerable<long> summonerIds)
        {
            IList<MasteryPages> pages = new List<MasteryPages>();
            List<long> toBeFetched = new List<long>();
            string reg = region.ToString();

            foreach (long id in summonerIds)
                if (!_masteryPages.Contains(reg, id.ToString()))
                    toBeFetched.Add(id);

            foreach (MasteryPages item in ApiCaller.GetMasteryPages(region, toBeFetched))
                _masteryPages.Add(item, reg, item.SummonerId.ToString());

            foreach (long id in summonerIds)
                pages.Add(_masteryPages[reg, id.ToString()]);

            return pages;
        }

        internal override IList<SummonerName> GetSummonerNames(
            Regions region, IEnumerable<long> summonerIds)
        {
            IList<SummonerName> names = new List<SummonerName>();
            List<long> toBeFetched = new List<long>();

            string reg = region.ToString();
            foreach (long id in summonerIds)    // first looking for already existing ids
            {
                string i = id.ToString();

                if (!_summonerNames.Contains(reg, i))   // if not already in cache
                {
                    if (_summoners.Contains(reg, i))    // first look in summoners
                    {
                        Summoner sum = _summoners[reg, i];
                        SummonerName sn = new SummonerName();
                        sn.Id = sum.Id;
                        sn.Name = sum.Name;

                        _summonerNames.Add(sn, reg, i); // add it to summonernames-cache
                    }
                    else                                // nowhere to find. has to be catched later
                        toBeFetched.Add(id);
                }
                if (_summonerNames.Contains(reg, i))    // recheck as it could have changed by the above
                    names.Add(_summonerNames[reg, i]);
            }

            if (toBeFetched.Count > 0)          // going to catch all unknown names.
            {
                var n = ApiCaller.GetSummonerNames(region, toBeFetched);
                foreach (var m in n)
                    _summonerNames.Add(m, reg, m.Id.ToString());
                names = names.Concat(n).ToList();
            }

            return names;
        }

        internal override IList<Summoner> GetSummoners(Regions region, IEnumerable<long> summonerIds)
        {
            IList<Summoner> summoners = new List<Summoner>();
            List<long> toBeFetched = new List<long>();
            string reg = region.ToString();

            foreach (long id in summonerIds)
                if (!_summoners.Contains(reg, id.ToString()))
                    toBeFetched.Add(id);

            foreach (Summoner item in ApiCaller.GetSummoners(region, toBeFetched))
                _summoners.Add(item, reg, item.Id.ToString());

            foreach (long id in summonerIds)
                summoners.Add(_summoners[reg, id.ToString()]);

            return summoners;
        }

        #region HELPMETHODS

        ///* Currently not possible, as the items (T) do not
        // * have a common interface to return their id.
        // */
        //private IList<T> StandardisedElementCatching<T>(Regions region, IEnumerable<long> summonerIds,
        //    IMultipleKeysTree<string, T> tree, Func<Regions, IEnumerable<long>, IList<T>> apifunc)
        //{
        //    IList<T> finalList = new List<T>();
        //    IList<long> toBeFetched = new List<long>();
        //    string reg = region.ToString();

        //    foreach (long id in summonerIds)
        //        if (!tree.Contains(reg, id.ToString()))
        //            toBeFetched.Add(id);

        //    foreach (T item in apifunc(region, toBeFetched))
        //        tree.Add(item, reg, item. // need interface for id -.-

        //    return finalList;
        //}

        #endregion
    }
}
