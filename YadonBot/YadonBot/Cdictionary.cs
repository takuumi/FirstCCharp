using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class Cdictionary
    {
        private List<string> _randomList = new();

        private List<ParseItem> _patternList = new();

        public List<string> Random
        { get => _randomList; }

        public List<ParseItem> Pattern
        {get => _patternList; }

        public Cdictionary()
        {

            MakeRandomList();
            MakePatternList();


        }


        private void MakeRandomList()
        {

            string[] r_lines = File.ReadAllLines(
                @"dics\random.txt",
                System.Text.Encoding.UTF8);


            foreach (string line in r_lines)
            {
                string str = line.Replace("\n", "");
                if (line != "")
                {
                    _randomList.Add(str);
                }

            }

        }


        private void MakePatternList()
        {
            string[] p_lines = File.ReadAllLines(
        @"dics\pattern.txt",
        System.Text.Encoding.UTF8);

            List<string> new_lines = new();
            foreach (string line in p_lines)
            {
                string str = line.Replace("\n", "");
                if (line != "")
                {
                    new_lines.Add(str);
                }

            }

            foreach (string line in new_lines)
            {
                string[] carveLine = line.Split(new char[] { '\t' });
                _patternList.Add(
                    new ParseItem(
                        carveLine[0], carveLine[1]
                        )
                    );

            }

        }

        internal void Study(string input, List<string[]> parts)
        {
            string userinput = input.Replace("\n", "");

            StudyRandom(userinput);
            StudyPattern(userinput, parts);

        }
        public void StudyRandom(string input)
        {
            string userInput = input.Replace("\n", "");
            if(_randomList.Contains(userInput) == false)
            {
                _randomList.Add(userInput);
            }
        }
        private void StudyPattern(string userinput, List<string[]> parts)
        {

            foreach(string[] morpheme in parts)
            {
                if (Analyzer.KeywordCheck(morpheme[1]).Success)
                {
                    ParseItem? depend = null;
                    foreach(ParseItem item in _patternList)
                    {
                        if (!string.IsNullOrEmpty(item.Match(userinput)))
                        {
                            depend = item;
                            break;

                        }
                    }

                    if(depend != null)
                    {
                        depend.AddPhrase(userinput);
                    }
                    else
                    {
                        _patternList.Add(new ParseItem(
                            morpheme[0], userinput));
                    }


                }
            }


        }


        public void Save()
        {
            File.WriteAllLines(
                @"dics\random.txt",
                _randomList,
                System.Text.Encoding.UTF8);

            List<string> patternLine = new();
            foreach(ParseItem item in _patternList)
            {
                patternLine.Add(item.MakeLine());
            }

            File.WriteAllLines(
                @"dics\pattern.txt",
                patternLine,
                System.Text.Encoding.UTF8);

        }


    }
}
