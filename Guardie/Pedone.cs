using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    public class Pedone : Personaggio
    {
        public Pedone(string nome) : base(nome)
        {
        }

        public override void OnAttaccare(object sender, EventArgs e)
        {
            string frase = "Il Pedone " + Nome + " si sta preparando";
            Comunica(frase);
        }
    }
}
