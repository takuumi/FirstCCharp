using MeCab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class Analyzer
    {

        public static List<string[]> Analize(string input)
        {
            var tagger = MeCabTagger.Create();
            List<string[]> result = new();

            foreach(var node in tagger.ParseToNodes(input))
            {
                if (node.CharType > 0)
                {
                    string[] surface_feature = new string[]
                    {
                        node.Surface,
                        node.Feature
                    };

                    result.Add(surface_feature);
                }
            }

            return result;
        }

        public static Match KeywordCheck(string part)
        {
            Regex rgx = new("名詞,(一般|固有名詞|サ変接続|形容動詞幹)");
            Match m = rgx.Match(part);
            return m;
        }
    }
}
