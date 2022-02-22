using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class Yadonchan
    {
        private string _name;

        private Cdictionary _dictionary;

        private CyadonEmotion _emotion;

        private RandomResponder _res_random;

        private RepeaResponder _res_repeat;

        private PatternResponder _res_pattern;

        private Responder _responder;

        public string Name { get => _name; }

        public CyadonEmotion Emotion { get => _emotion; }  

        public Yadonchan(string name)
        {
            _name = name;

            _dictionary = new Cdictionary();

            _emotion = new CyadonEmotion(_dictionary);

            _res_random = new RandomResponder("Random", _dictionary);
            _res_repeat = new RepeaResponder("Repeat", _dictionary);
            _res_pattern = new PatternResponder("Pattern", _dictionary);
            _responder = new Responder("Responder", _dictionary);


        }

        public string Dialogue(string input)
        {
            _emotion.Update(input);




            Random rnd = new Random();
            int num = rnd.Next(0, 10);
            //7
            if (num < 100)
            {
                _responder = _res_pattern;
            }
            else if(num < 9)
            {
                _responder = _res_random;
            }
            else
            {
                _responder = _res_repeat;
            }

            return _responder.Response(input, _emotion.Mood);
        }

        public string GetName()
        {
            return _responder.Name;
        }

    }

}
