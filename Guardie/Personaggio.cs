using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    public abstract class Personaggio
    {
        public string Nome { get; set; }
        public event EventHandler<string> Messaggio;

        public Personaggio(string nome)
        {
            Nome = nome;
        }

        protected void Comunica(string frase)
        {
            if (Messaggio != null)
            {
                Messaggio.Invoke(this, frase);
            }
        }

        public abstract void OnAttaccare(object sender, EventArgs e);
    }
}
