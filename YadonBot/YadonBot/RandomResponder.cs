using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class RandomResponder : Responder
    {

        public RandomResponder(string name, Cdictionary dic) : base(name, dic)
        {
        }

        public override string Response(string input, int mood)
        {
            int seed = Environment.TickCount;
            Random rnd = new(seed);

            return Cdictionary.Random[rnd.Next(0, Cdictionary.Random.Count)];
        }

    }
}
