using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    public class Re
    {
        public delegate void ReAttaccatoHandler(string nomeRe);
        public string Nome { get; set; }
        public event ReAttaccatoHandler Attaccato;

        public Re(string nome)
        {
            Nome = nome;
        }

        protected virtual void OnAttaccato()
        {
            if (Attaccato != null)
            {
                Attaccato(Nome);
            }
        }

        public string SubisciAttacco()
        {
            OnAttaccato();
            return "Il Re " + Nome + " è sotto attacco";
        }
    }
}
