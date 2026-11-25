using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guardie
{
    internal class Gestionale
    {
        public Re Sovrano { get; set; }
        public List<Guardia> Guardie { get; set; }
        public List<Pedone> Pedoni { get; set; }

        public event EventHandler Attaccare;
        public event EventHandler<string> Cattura;

        private List<string> comandi;
        private int indiceComando;
        private bool terminato;

        public Gestionale()
        {
            Guardie = new List<Guardia>();
            Pedoni = new List<Pedone>();
            comandi = new List<string>();
            indiceComando = 0;
            terminato = false;
        }

        public void CaricaComandi(string[] righe, int indiceInizio)
        {
            comandi.Clear();
            indiceComando = 0;
            terminato = false;

            for (int i = indiceInizio; i < righe.Length && comandi.Count < 100; i++)
            {
                comandi.Add(righe[i].Trim());
            }
        }

        protected virtual void OnAttacca()
        {
            if (Attaccare != null)
            {
                Attaccare.Invoke(this, EventArgs.Empty);
            }
        }

        protected virtual void OnCattura(string nome)
        {
            if (Cattura != null)
            {
                Cattura.Invoke(this, nome);
            }
        }

        public bool EseguiProssimo()
        {
            if (terminato || indiceComando >= comandi.Count)
            {
                return false;
            }

            string comando = comandi[indiceComando];
            indiceComando++;

            if (comando == "End")
            {
                terminato = true;
                return false;
            }
            else if (comando == "Attacca Re")
            {
                OnAttacca();
                return true;
            }
            else if (comando.StartsWith("Cattura "))
            {
                string nome = comando.Substring("Cattura ".Length).Trim();
                RimuoviPersonaggio(nome);
                OnCattura(nome);
                return true;
            }
            else
            {
                return true;
            }
        }

        private void RimuoviPersonaggio(string nome)
        {
            for (int i = 0; i < Guardie.Count; i++)
            {
                Personaggio p = Guardie[i] as Personaggio;
                if (p != null && p.Nome == nome)
                {
                    if (Attaccare != null)
                    {
                        Attaccare -= Guardie[i].OnAttaccare;
                    }
                    Guardie.RemoveAt(i);
                    return;
                }
            }

            for (int i = 0; i < Pedoni.Count; i++)
            {
                Personaggio p = Pedoni[i] as Personaggio;
                if (p != null && p.Nome == nome)
                {
                    if (Attaccare != null)
                    {
                        Attaccare -= Pedoni[i].OnAttaccare;
                    }
                    Pedoni.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
