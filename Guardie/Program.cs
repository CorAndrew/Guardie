using System;
using System.Collections.Generic;
using System.IO;

namespace Guardie
{
    internal class Program
    {
        const string FileInput = "commands.txt";
        const string FileOutput = "output.txt";

        static Gestionale gestore;
        static List<Personaggio> listaPersonaggi = new List<Personaggio>();

        static void Main(string[] args)
        {
            File.WriteAllText(FileOutput, "");

            gestore = new Gestionale();
            gestore.Cattura += Gestore_Cattura;

            string[] righe = File.ReadAllLines(FileInput);

            if (righe.Length > 0)
            {
                Re re = new Re(righe[0].Trim());
                listaPersonaggi.Add(re);
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

            gestore.CaricaComandi(righe);

            while (gestore.EseguiProssimo())
            {
            }
        }

        static void Arruola(string ruolo, string nome)
        {
            if (ruolo == "Guardia")
            {
                Guardia g = new Guardia(nome);
                listaPersonaggi.Add(g);
                g.Messaggio += Personaggio_Messaggio;
                gestore.Attaccare += g.OnAttaccare;
            }
            else if (ruolo == "Pedone")
            {
                Pedone p = new Pedone(nome);
                listaPersonaggi.Add(p);
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