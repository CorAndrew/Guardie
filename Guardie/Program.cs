using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Guardie
{
    internal class Program
    {
        const string FileInput = "input.txt";
        const string FileOutput = "output.txt";

        static Gestionale gestore;
        static List<Guardia> listaGuardie;
        static List<Pedone> listaPedoni;

        static void Main(string[] args)
        {
            File.WriteAllText(FileOutput, "");

            gestore = new Gestionale();
            listaGuardie = new List<Guardia>();
            listaPedoni = new List<Pedone>();

            gestore.Guardie = listaGuardie;
            gestore.Pedoni = listaPedoni;
            gestore.Cattura += Gestore_Cattura;

            string[] righe = File.ReadAllLines(FileInput);

            if (righe.Length > 0)
            {
                Re re = new Re(righe[0].Trim());
                gestore.Sovrano = re;
                re.Messaggio += Personaggio_Messaggio;
                gestore.Attaccare += re.OnAttaccare;
            }

            if (righe.Length > 1 && righe[1].Trim() != "")
            {
                string[] nomiGuardie = righe[1].Trim().Split(' ');
                for (int i = 0; i < nomiGuardie.Length; i++)
                {
                    if (nomiGuardie[i] != "")
                    {
                        Arruola("Guardia", nomiGuardie[i]);
                    }
                }
            }

            if (righe.Length > 2 && righe[2].Trim() != "")
            {
                string[] nomiPedoni = righe[2].Trim().Split(' ');
                for (int i = 0; i < nomiPedoni.Length; i++)
                {
                    if (nomiPedoni[i] != "")
                    {
                        Arruola("Pedone", nomiPedoni[i]);
                    }
                }
            }

            gestore.CaricaComandi(righe, 3);

            while (gestore.EseguiProssimo())
            {
            }
        }

        static void Arruola(string ruolo, string nome)
        {
            if (ruolo == "Guardia")
            {
                Guardia g = new Guardia(nome);
                listaGuardie.Add(g);
                g.Messaggio += Personaggio_Messaggio;
                gestore.Attaccare += g.OnAttaccare;
            }
            else if (ruolo == "Pedone")
            {
                Pedone p = new Pedone(nome);
                listaPedoni.Add(p);
                p.Messaggio += Personaggio_Messaggio;
                gestore.Attaccare += p.OnAttaccare;
            }
        }

        static void Personaggio_Messaggio(object sender, string frase)
        {
            Console.WriteLine(frase);

            Re reMittente = sender as Re;
            if (reMittente != null)
            {
                File.AppendAllText(FileOutput, frase + Environment.NewLine);
            }
        }

        static void Gestore_Cattura(object sender, string nome)
        {
            Console.WriteLine("Cattura " + nome);
        }
    }
}
