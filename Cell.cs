using System;
using System.Collections.Generic;
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
            color = Color.Black;
            genetic = "A";
        }

        public void Mutation()
        {

            if (genetic.Length > 3)
            {

                int i = 0;
                string chaine = "";

                while (i < genetic.Length - 3)
                {
                    chaine = genetic.Substring(i, 3);
                    switch (chaine)
                    {
                        case "TGT":
                            color = Color.FromArgb(0, 0, 0);
                            break;
                        case "ATT":
                            color = Color.FromArgb(0, 0, 255);
                            break;
                        case "CTC":
                            color = Color.FromArgb(0, 255, 255);
                            break;
                        case "ACT":
                            color = Color.FromArgb(255, 0, 255);
                            break;
                        case "GTC":
                            color = Color.FromArgb(255, 165, 0);
                            break;
                        case "GAA":
                            color = Color.FromArgb(0, 255, 0);
                            break;
                    }
                    i++;
                }
            }


            
            size += 5;
            
        }
    }
}
