using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelluleMutante2
{
    public class Cell
    {
        public int size;
        public Color color;
        public string genetic;
        private Random rnd = new Random();

        public Cell()
        {
            size = 10;
            color = Color.FromArgb(0, 0, 0);
            genetic = "A";
        }

        public void Mutation()
        {

            string tempGenetic = genetic;

            string[] Nucleotide = { "A", "T", "C", "G" };

            if (genetic.Length > 3)
            {

                int i = 0;
                string chaine = "";
                Dictionary<string, int> Occurences = new Dictionary<string, int>
                {
                    { "TGT", 0 },
                    { "ATT", 0 },
                    { "CTC", 0 },
                    { "ACT", 0 },
                    { "GTC", 0 },
                    { "GAA", 0 }
                };

                while (i < genetic.Length - 3)
                {
                    int temprnd = rnd.Next(0, 100);
                    chaine = genetic.Substring(i, 3);
                    switch (chaine)
                    {
                        case "TGT":
                            Occurences["TGT"] += 1;
                            break;
                        case "ATT":
                            Occurences["ATT"] += 1;
                            break;
                        case "CTC":
                            Occurences["CTC"] += 1;
                            break;
                        case "ACT":
                            Occurences["ACT"] += 1;
                            break;
                        case "GTC":
                            Occurences["TGT"] += 1;
                            break;
                        case "GAA":
                            Occurences["TGT"] += 1;
                            break;
                    }

                    if (temprnd <= 5)
                    {
                        tempGenetic = tempGenetic.Insert(i + 1, Nucleotide[rnd.Next(0, 4)]); 
                    }

                    i++;
                }


                int MaxPatern = Occurences.Values.Max();
                int MaxIndex = Occurences.Values.ToList().IndexOf(MaxPatern);


                switch (MaxIndex)
                {
                    case 0:
                        color = Color.FromArgb(0, 0, 0);
                        break;
                    case 1:
                        color = Color.FromArgb(0, 0, 255);
                        break;
                    case 2:
                        color = Color.FromArgb(0, 255, 255);
                        break;
                    case 3:
                        color = Color.FromArgb(255, 0, 255);
                        break;
                    case 4:
                        color = Color.FromArgb(255, 165, 0);
                        break;
                    case 5:
                        color = Color.FromArgb(0, 255, 0);
                        break;
                    default:
                        color = Color.FromArgb(0, 0, 0);
                        break;

                }


            }
            int j = 0;
            List<string> tempList = new List<string>();
            while (j < genetic.Length)
            {
                switch (genetic[j])
                {
                    case 'A':
                        int tempa = rnd.Next(0, 100);
                        if (tempa <= 15)
                        {
                            tempList.Add("T");
                        }
                        break;
                    case 'T':
                        int tempt = rnd.Next(0, 100);
                        if (tempt <= 7)
                        {
                            tempList.Add("AA");
                        }
                        break;
                    case 'C':
                        int tempc = rnd.Next(0, 100);
                        if (tempc <= 21)
                        {
                            tempList.Add("G");
                        }
                        break;
                    case 'G':
                        int tempg = rnd.Next(0, 100);
                        if (tempg <= 4)
                        {
                            tempList.Add("CG");
                        }
                        break;
                }
                j++;
            }

            tempGenetic += string.Join("", tempList);

            int compteur = 0;
            foreach (char letter in genetic)
            {
                if (letter == 'T')
                {
                    compteur++;
                }
            }
            
            size += tempGenetic.Length / 5 + Math.Min(compteur, genetic.Length);
            
            genetic = tempGenetic;


            
        }
    }
}
