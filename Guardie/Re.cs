using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    public class Re : Personaggio
    {
        public Re(string nome) : base(nome)
        {
        }

        public override void OnAttaccare(object sender, EventArgs e)
        {
            string frase = "Il Re " + Nome + " è sotto attacco";
            Comunica(frase);
        }
    }
}
