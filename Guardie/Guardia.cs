using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    public class Guardia : Personaggio
    {
        public Guardia(string nome) : base(nome)
        {
        }

        public override void OnAttaccare(object sender, EventArgs e)
        {
            string frase = "La Guardia " + Nome + " sta difendendo";
            Comunica(frase);
        }
    }
}
