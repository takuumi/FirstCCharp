using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class ParseItem
    {
        private string _pattern = "";
        private List<Dictionary<string, string>> _phases = new();
        private int _modify;

        public int Modify { get => _modify;}

        public ParseItem(string pattern, string phrases)
        {
            string SEPARATOR = @"^((-?\d+)##)?(.*)$";

            Regex rgx = new(SEPARATOR);
            MatchCollection m = rgx.Matches(pattern);
            Match mach = m[0];

            _modify = 0;

            if (string.IsNullOrEmpty(mach.Groups[2].Value) != true)
            {
                _modify = Convert.ToInt32(mach.Groups[2].Value);
            }

            _pattern = mach.Groups[3].Value;
            foreach (string phrase in phrases.Split(new Char[] { '|' })){
                Dictionary<string, string> dic = new();
                MatchCollection m2 = rgx.Matches(phrase);
                Match mach2 = m2[0];
                dic["need"] = "0";

                if (string.IsNullOrEmpty(mach2.Groups[2].Value) != true)
                {
                    dic["need"] = mach2.Groups[2].Value;
                }

                dic["phrase"] = mach2.Groups[3].Value;

                _phases.Add(dic);

            }
        }

        public string Match(string str)
        {
            Regex rgx = new(_pattern);
            Match mtc = rgx.Match(str);
            return mtc.Value;
        }

        public string Choise(int mood)
        {
            List<string> choises = new();
            foreach (Dictionary<string, string> dic in _phases)
            {
                if (Suitable(
                    Convert.ToInt32(dic["need"]),
                    mood))
                {
                    choises.Add(dic["phrase"]);

                }
            }

            if(choises.Count == 0)
            {
                return null;
            }
            else
            {
                int seed = Environment.TickCount;
                Random rnd = new (seed);
                return choises[rnd.Next(0, choises.Count)];
            }

        }

        private bool Suitable(int need, int mood)
        {
            if (need == 0)
            {
                return true;
            }
            else if (need > 0)
            {
                return (mood > need);
            }else
            {
                return (mood < need);
            }
        }
    }
}
