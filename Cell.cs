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

            if (genetic.Length > 3)
            {

                int i = 0;
                string chaine = "";
                int TotTGT = 0;
                int TotATT = 0;
                int TotCTC = 0;
                int TotACT = 0;
                int TotGTC = 0;
                int TotGAA = 0;

                while (i < genetic.Length - 3)
                {
                    chaine = genetic.Substring(i, 3);
                    switch (chaine)
                    {
                        case "TGT":
                            TotTGT += 1;
                            break;
                        case "ATT":
                            TotATT += 1;
                            break;
                        case "CTC":
                            TotCTC += 1;
                            break;
                        case "ACT":
                            TotACT += 1;
                            break;
                        case "GTC":
                            TotGTC += 1;
                            break;
                        case "GAA":
                            TotGAA += 1;
                            break;
                    }
                    i++;
                }

                int[] totals = { TotTGT, TotATT, TotCTC, TotACT, TotGTC, TotGAA };
                int MaxPatern = totals.Max();

                switch (MaxPatern)
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
                        color = Color.FromArgb(255, 0, 0);
                        break;

                }

                Debug.Print("TGT: " + TotTGT + " ATT: " + TotATT + " CTC: " + TotCTC + " ACT: " + TotACT + " GTC: " + TotGTC + " GAA: " + TotGAA);

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

            genetic += string.Join("", tempList);

            size += 5;
            
        }
    }
}
