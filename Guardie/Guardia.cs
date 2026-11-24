using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    public class Guardia
    {
        public string Nome { get; set; }

        public Guardia(string nome)
        {
            Nome = nome;
        }

        public void Re_Attaccato(string nomeRe)
        {
            Console.WriteLine("La Guardia " + Nome + " sta difendendo");
        }
    }
}
