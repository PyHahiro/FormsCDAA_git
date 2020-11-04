using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CDAA_ProjectForms
{

    public class LesConsoles
    {
        private int taille;
        public int Taille { get { return listC.Count; } set { taille = value; } }

        private List<ConsoleJeu> listC;

        public LesConsoles()
        {
            listC = new List<ConsoleJeu>();
            this.taille = 0;
        }

        /*
         * Ajout d'une Console
         */

        public void AjoutConsole(ConsoleJeu c1)
        {
            this.listC.Add(c1);
            this.Taille += 1;
        }

        /*
         * Suppression d'une Console par son Nom
         */

        public void DelConsole(String nom)
        {
            for (int i = 0; i < this.Taille; i++)
            {
                if (this.listC.ElementAt(i).Nom.Equals(nom))
                    this.listC.RemoveAt(i);
            }
        }

        /*
         * Accesseur / ToString
         */

        public ConsoleJeu GetConsole(int i)
        {
            return listC.ElementAt(i);
        }

        public override String ToString()
        {
            String s = "";
            for (int i = 0; i < listC.Count; i++)
            {
                s += listC.ElementAt(i).ToString();
                s += "\n";
            }
            return s;
        }

        /*
         *  Pre-remplissage d'une liste de consoles pour notre Catalogue
         */

        public void Init()
        {
            ConsoleJeu c1 = new ConsoleJeu("PS4");
            ConsoleJeu c2 = new ConsoleJeu("Switch");
            ConsoleJeu c3 = new ConsoleJeu("Xbox One");
            this.AjoutConsole(c1);
            this.AjoutConsole(c2);
            this.AjoutConsole(c3);
        }
    }
}
