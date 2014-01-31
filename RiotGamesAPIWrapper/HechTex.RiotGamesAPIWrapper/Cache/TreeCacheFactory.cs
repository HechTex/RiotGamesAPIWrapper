using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsExtensions.Constructs.Tree;
using HechTex.RiotGamesAPIWrapper.APIConstants;
using HechTex.RiotGamesAPIWrapper.Model;
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
         * - storing
         * - automatic clearing (put a timestamp onto it)
         * - maybe forced clear possible
         */

        private Dictionary<Regions, IList<Champion>> _champions;
        private IMultipleKeysTree<string, IList<RunePage>> _runePages;
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
            _runePages = new MultipleHashTree<string, IList<RunePage>>();
            _summoners = new MultipleHashTree<string, Summoner>();
            _summonerNames = new MultipleHashTree<string, SummonerName>();
        }

        internal override IList<Champion> GetChampions(Regions region)
        {
            if (!_champions.ContainsKey(region))
                _champions.Add(region, ApiCaller.GetChampions(region));

            return _champions[region];
        }

        internal override IList<RunePage> GetRunePages(
            Regions region, long summonerId)
        {
            string reg = region.ToString();
            string id = summonerId.ToString();

            if (!_runePages.Contains(reg, id))
                _runePages.Add(ApiCaller.GetRunePages(region, summonerId),
                    reg, id);

            return _runePages[reg, id];

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
    }
}
