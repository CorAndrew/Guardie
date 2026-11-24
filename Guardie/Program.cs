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
        static void Main(string[] args)
        {
            string[] righe = File.ReadAllLines("commands.txt");
            File.WriteAllText("output.txt", "");

            Re re = new Re(righe[0]);

            List<Guardia> guardie = new List<Guardia>();
            string[] nomiGuardie = righe[1].Split(' ');
            for (int i = 0; i < nomiGuardie.Length; i++)
            {
                Guardia g = new Guardia(nomiGuardie[i]);
                guardie.Add(g);
                re.Attaccato += g.Re_Attaccato;
            }

            List<Pedone> pedoni = new List<Pedone>();
            string[] nomiPedoni = righe[2].Split(' ');
            for (int i = 0; i < nomiPedoni.Length; i++)
            {
                Pedone p = new Pedone(nomiPedoni[i]);
                pedoni.Add(p);
                re.Attaccato += p.Re_Attaccato;
            }

            for (int i = 3; i < righe.Length; i++)
            {
                string cmd = righe[i];
                Console.WriteLine("> " + cmd);

                if (cmd == "End")
                {
                    Console.WriteLine("Simulazione terminata");
                    break;
                }
                else if (cmd == "Attacca Re")
                {
                    string fraseRe = re.SubisciAttacco();
                    Console.WriteLine(fraseRe);
                    File.AppendAllText("output.txt", fraseRe + Environment.NewLine);
                }
                else if (cmd.StartsWith("Cattura "))
                {
                    string nomeDaCatturare = cmd.Substring(8);

                    for (int g = 0; g < guardie.Count; g++)
                    {
                        if (guardie[g].Nome == nomeDaCatturare)
                        {
                            re.Attaccato -= guardie[g].Re_Attaccato;
                            guardie.RemoveAt(g);
                            break;
                        }
                    }

                    for (int p = 0; p < pedoni.Count; p++)
                    {
                        if (pedoni[p].Nome == nomeDaCatturare)
                        {
                            re.Attaccato -= pedoni[p].Re_Attaccato;
                            pedoni.RemoveAt(p);
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Comando non valido");
                }
            }
        }
    }
}
