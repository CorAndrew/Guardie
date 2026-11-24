using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    public class Pedone
    {
        public string Nome { get; set; }

        public Pedone(string nome)
        {
            Nome = nome;
        }

        public void Re_Attaccato(string nomeRe)
        {
            Console.WriteLine("Il Pedone " + Nome + " si sta preparando");
        }
    }
}
