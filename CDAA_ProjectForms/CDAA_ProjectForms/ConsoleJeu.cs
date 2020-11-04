using System;
using System.Collections.Generic;
using System.Text;
namespace CDAA_ProjectForms
{
    public class ConsoleJeu : IEquatable<ConsoleJeu>
    {
        private String nom;
        public String Nom { get { return nom; } set { nom = value; } }
        // Le nom de la console
        private String capacite;
        public String Capacite { get { return capacite; } set { capacite = value; } }
        //Sa capacité (En Mo/Giga/Terra)
        private String couleur;
        public String Couleur { get { return couleur; } set { couleur = value; } }
        //Sa couleur
        private double prix;
        public double Prix { get { return prix; } set { prix = value; } }
        //Son prix
        private String description;
        public String Description { get { return description; } set { description = value; } }
        //Une description
        private Boolean neuf;
        public Boolean Neuf { get { return neuf; } set { neuf = value; } }
        //Savoir si elle est neuf ou d'occasion

        public override String ToString()
        {
            return ("Nom : " + this.nom + " | Capacite : " + this.capacite + " | Couleur : " + this.couleur + " Prix : " + this.prix + " | Description : " + this.description
                + " | Neuf : " + this.neuf);
        }

        /*
         * Constructeur de base
         */

        public ConsoleJeu()
        {
            this.nom = "Aucun";
            this.capacite = "Inconnue";
            this.couleur = "Inconnue";
            this.prix = 0.0;
            this.description = "Aucune";
            this.neuf = true;
        }

        /*
         * Constructeur nom
         */

        public ConsoleJeu(String n) : this()
        {
            this.nom = n;
        }

        /*
         * Constructeur complet
         */

        public ConsoleJeu(String n, String c, String coul, double prix, String desc, Boolean neuf)
        {
            this.nom = n;
            this.capacite = c;
            this.couleur = coul;
            this.prix = prix;
            this.description = desc;
            this.neuf = neuf;
        }

        /*
         *  Equals
         */

        public bool Equals(ConsoleJeu c)
        {
            return this.Nom.Equals(c.Nom);
        }
        public override bool Equals(Object o)
        {
            if (o == null) return false;
            else
            {
                ConsoleJeu c2 = o as ConsoleJeu;
                return this.Equals(c2);
            }
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}