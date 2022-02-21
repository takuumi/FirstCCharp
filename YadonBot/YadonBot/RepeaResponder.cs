using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class RepeaResponder : Responder
    {
        public RepeaResponder(string name) : base(name) 
        {
        }

        public override string Response(string input)
        {
            return String.Format("{0}ってなにドヤ？", input);
        }
    }

}
