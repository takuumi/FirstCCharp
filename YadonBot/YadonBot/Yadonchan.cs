using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class Yadonchan
    {
        private RandomResponder _res_random;

        private RepeaResponder _res_repeat;

        private Responder _responder;

        public string? Name { get; set; }

        public Yadonchan(string name)
        {
            Name = name;

            _res_random = new RandomResponder("Random");
            _res_repeat = new RepeaResponder("Repeat");
            _responder = new Responder("Responder");


        }

        public string Dialogue(string input)
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 10);
            if (num < 6)
            {
                _responder = _res_random;
            }
            else
            {
                _responder = _res_repeat;
            }

            return _responder.Response(input);
        }

        public string GetName()
        {
            return _responder.Name;
        }

    }

}
