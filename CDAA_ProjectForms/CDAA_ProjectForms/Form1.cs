namespace CDAA_ProjectForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;


    public partial class LeBoJeu : Form
    {
        Catalogue c = new Catalogue();
        ImageList il = new ImageList();
        public LeBoJeu()
        {
            c.InitCatalogue();
            InitializeComponent();
            InitListeGenres();
            InitListJeux();
            Init_All_Game();
        }

        public void InitListeGenres()
        {
            comboBox1.DataSource = Enum.GetValues(typeof(Genres));
        }

        /*
         * 
         */

        public void ReloadListImages()
        {
            ListePhotos.DrawMode = DrawMode.OwnerDrawVariable;
            foreach (Jeu j in c.Lj.Listj)
            {
                if (comboBox1.SelectedItem.Equals(j.Genre) && j.Img != null)
                {
                    il.Images.Add(j.Img);
                    ListePhotos.Items.Add(j.Img);
                }
            }
            il.ImageSize = new Size(150, 150);
            ListePhotos.ItemHeight = 150;
        }

        //Pour initialiser tout les jeux dans la liste des photos
        public void Init_All_Game()
        {
            Clear();
            ListePhotos.DrawMode = DrawMode.OwnerDrawVariable;
            foreach (Jeu j in c.Lj.Listj)
            {
                il.Images.Add(j.Img);
                ListePhotos.Items.Add(j.Img);
                listBox1.Items.Add(j.Nom);
            }
            il.ImageSize = new Size(150, 150);
            ListePhotos.ItemHeight = 150;

        }
        //Liste de jeu
        public void InitListJeux()
        {
            Clear();
            foreach (Jeu j in c.Lj.Listj)
            {
                if (j.Genre.Equals(comboBox1.SelectedItem))
                {
                    listBox1.Items.Add(j.Nom);
                }
            }
        }
        //Cliquer sur une image de la liste de gauche
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Object temp = (Object) ListePhotos.SelectedItem;
            foreach(Jeu j in c.Lj.Listj)
            {
                if (temp.Equals((Object) j.Img))
                {
                    pictureBox1.Image = j.Img;
                    Description.Text = j.ToString();
                }
                    
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitListJeux();
            ReloadListImages();
            //InitListImages();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = c.GetJeuNom((String)listBox1.SelectedItem).Img;
            Description.Text = c.GetJeuNom((String)listBox1.SelectedItem).ToString();
        }

        private void ListePhotos_DrawItem(object sender, DrawItemEventArgs e)
        {
            Point p = e.Bounds.Location;
            if (e.Graphics != null && e.Index > -1 && il.Images.Count > 0)
                il.Draw(e.Graphics, p, e.Index);
        }

       

        //Le clear
        public void Clear()
        {
            il = new ImageList();
            ListePhotos.Items.Clear();
            pictureBox1.Image = null;
            Description.Text = "";
            listBox1.Items.Clear();
        }

        //Cliquer sur le bouton tous les jeux
        private void button1_Click(object sender, EventArgs e)
        {
            Init_All_Game();

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaisieJeuDlg saisie = new SaisieJeuDlg();
            DialogResult dial = saisie.ShowDialog();
            if (dial == DialogResult.OK)
            {
                if (saisie.LeJeu.Img == null)
                    saisie.LeJeu.Img = Properties.Resources.axel;
                c.AjoutJeu(saisie.LeJeu);
                
            }
            Init_All_Game();
        }

        private void visualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void lesJeuxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisuJeuDlg diag = new VisuJeuDlg(c.Lj);
            diag.ShowDialog();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifDlg diag = new ModifDlg(c.Lj);
            diag.ShowDialog();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupprimerDlg diag = new SupprimerDlg(c.Lj);
            diag.ShowDialog();
            Init_All_Game();
        }
    }
}
