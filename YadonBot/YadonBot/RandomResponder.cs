using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadonBot
{
    internal class RandomResponder : Responder
    {
        private string[] _responses =
        {
            "いい天気どやぁ",
            "おやすみどやぁ",
            "ドドヤ、ヤドドヤァ！",
            "?",
            "スヤスヤ・・・",
            "ドヤァ"
        };


        public RandomResponder(string name) : base(name)
        {
        }

        public override string Response(string input)
        {
            Random rnd = new Random();

            return _responses[rnd.Next(0, _responses.Length)];
        }

    }
}
