using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class Responder
    {

        public string? Name { get; set; }

        public Responder(string name)
        {
            Name = name;
        }

        public virtual string Response(string input)
        {
            {
                return "";
            };
        }

    }
}
