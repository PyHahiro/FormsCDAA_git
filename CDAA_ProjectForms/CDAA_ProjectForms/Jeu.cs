﻿using System;
using System.Drawing;

namespace CDAA_ProjectForms
{
    public enum Genres
    {
        Aucun,
        Plateforme,
        Action_RPG,
        Action_Aventure,
        Football,
        Course_Auto,
    };

    public class Jeu : IEquatable<Jeu>, LesComparaisons<Jeu>
    {
        /*
         *  Accesseurs - Mutateurs
         */

        private string nom;
        public string Nom { get { return nom; } set { nom = value; } }

        private string description;
        public string Description { get { return description; } set { description = value; } }
        //
        private string plateforme;
        public string Plateforme { get { return plateforme; } set { plateforme = value; } }
        //
        private Genres genre;
        public Genres Genre { get { return genre; } set { genre = value; } }
        //
        private string editeur;
        public string Editeur { get { return editeur; } set { editeur = value; } }
        //
        private double prix;
        public double Prix { get { return prix; } set { prix = value; } }
        //
        private DateTime date;
        public DateTime Date { get { return date; } set { date = value; } }
        //
        private Boolean recondition;
        public Boolean Recondition { get { return recondition; } set { recondition = value; } }
        //
        private Image img;

        public Image Img { get { return img; } set { img = value; } }


        /*
            toString() Affiche des jeux
         */
        public override String ToString()
        {
            return ("Nom : " + this.nom + "\nDescription : " + this.description + "\nPlateforme : " + this.plateforme + "\nGenre : " + Enum.GetName(typeof(Genres), genre) + "\nEditeur : " + this.editeur
                + "\nPrix : " + this.prix + "\nDate :" + this.date + "\nReconditionné : " + this.recondition);
        }
        /*
             Constructeur 0
         */
        public Jeu()
        {
            this.nom = "Aucun";
            this.description = "Aucune";
            this.plateforme = "Pas de plateforme connue";
            this.genre = Genres.Aucun;
            this.editeur = "Pas d'editeur";
            this.prix = 0.0;
            this.date = new DateTime();
            this.recondition = false;
            this.Img = Properties.Resources.axel;
        }

        /*
            Constructeur avec Nom
         */

        public Jeu(String n) : this()
        {
            this.nom = n;
        }

        /*
         * Constructeur Complet
         */
        public Jeu(Jeu j)
        {
            this.nom = j.Nom;
            this.description = j.Description;
            this.plateforme = j.Plateforme;
            this.genre = j.Genre;
            this.editeur = j.Editeur;
            this.prix = j.Prix;
            this.date = j.Date;
            this.recondition = j.Recondition;
            this.img = j.Img;
        }
        public Jeu(String n, String d, String p, Genres g, String e, double prix, DateTime dat, Boolean b)
        {
            this.nom = n;
            this.description = d;
            this.plateforme = p;
            this.genre = g;
            this.editeur = e;
            this.prix = prix;
            this.date = dat;
            this.recondition = b;
        }
        /*
            Equals
         */
        public bool Equals(Jeu j)
        {
            if (j != null)
            {
                return this.Nom.Equals(j.Nom);
            }
            else
                return false;
        }

        public override bool Equals(Object o)
        {
            if (o == null) return false;
            else
            {
                Jeu j2 = o as Jeu;
                return this.Equals(j2);
            }
        }

        public override int GetHashCode()
        {
            return 0;
        }

        /*
         * CompareTo
         */

        public int CompareNom(Jeu j)
        {
            return this.Nom.CompareTo(j.Nom);
        }

        public int ComparePrix(Jeu j)
        {
            return this.Prix.CompareTo(j.Prix);
        }
    }
}
