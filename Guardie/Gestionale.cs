using System;
using System.Collections.Generic;

namespace Guardie
{
    internal class Gestionale
    {
        public event EventHandler Attaccare;
        public event EventHandler<string> Cattura;

        private List<string> comandi = new List<string>();
        private int indiceComando;
        private bool terminato;

        public Gestionale()
        {
            indiceComando = 0;
            terminato = false;
        }

        public void CaricaComandi(string[] righe)
        {
            comandi.Clear();
            indiceComando = 0;
            terminato = false;

            for (int i = 3; i < righe.Length && comandi.Count < 100; i++)
            {
                comandi.Add(righe[i].Trim());
            }
        }

        public bool EseguiProssimo()
        {
            if (terminato || indiceComando >= comandi.Count)
                return false;

            string comando = comandi[indiceComando++];

            if (comando == "Attacca")
                OnAttacca();
            else if (comando.StartsWith("Cattura "))
                OnCattura(comando.Substring(8));

            return true;
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
    }
}