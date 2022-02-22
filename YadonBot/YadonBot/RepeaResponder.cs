using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class RepeaResponder : Responder
    {
        public RepeaResponder(string name, Cdictionary dic) : base(name, dic) 
        {
        }

        public override string Response(string input, int mood)
        {
            return String.Format("{0}ってなにドヤ？", input);
        }
    }

}
