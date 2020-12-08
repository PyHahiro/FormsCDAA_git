using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDAA_ProjectForms
{
    public partial class SaisieJeuDlg : Form
    {
        private Jeu leJeu;
        public Jeu LeJeu { get { return leJeu; } set { leJeu = value; } }
        private Image ph;
        public SaisieJeuDlg()
        {
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            InitializeComponent();
            leJeu = new Jeu();
            ph = null;
            InitListGenres();
        }

        public void InitListGenres()
        {
            //Jeu
            comboBox2.DataSource = Enum.GetValues(typeof(Genres));
            //JeuRetro
            comboBox1.DataSource = Enum.GetValues(typeof(Genres));
            comboBox3.DataSource = Enum.GetValues(typeof(Etats));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) 
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
             * Bouton Valider
             */
            float prix;
            bool recond = false;
            DateTime ds = dateTimePicker2.Value;
            Genres cat = (Genres)comboBox2.SelectedItem;
            if (textBox8.Text != "")
                prix = Single.Parse(textBox8.Text);
            else prix = 0;
            if (radioButton3.Checked)
                recond = true;
            this.leJeu = new Jeu(Nom.Text, Desc.Text, Plat.Text, cat, Edit.Text, prix, ds, recond);
            leJeu.Img = this.ph;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*
           * Bouton Parcourir
           */
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                string fichier = dlg.FileName;
                textBox1.Text = fichier;
                ph = Image.FromFile(fichier);
                pictureBox2.Image = ph.GetThumbnailImage(pictureBox2.Width, pictureBox2.Height, null, IntPtr.Zero);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            * Bouton Annuler
            */
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            /*
          * Bouton Parcourir
          */
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult res = dlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                string fichier = dlg.FileName;
                textBox2.Text = fichier;
                ph = Image.FromFile(fichier);
                pictureBox1.Image = ph.GetThumbnailImage(pictureBox1.Width, pictureBox1.Height, null, IntPtr.Zero);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*
            * Bouton Valider
            */
            float prix;
            bool recond = false;
            bool notice = false;
            DateTime ds = dateTimePicker1.Value;
            Genres cat = (Genres)comboBox1.SelectedItem;
            Etats et = (Etats)comboBox3.SelectedItem;//etat, a faire notice
            if (textBox7.Text != "")
                prix = Single.Parse(textBox7.Text);
            else prix = 0;
            if (Noti.Checked)
                notice = true;

            if (radioButton1.Checked)
                recond = true;
            Jeu temp = new Jeu(textBox3.Text, textBox4.Text, textBox5.Text, cat, textBox6.Text, prix, ds, recond);

            this.leJeu = new JeuRetro(temp);
            ((JeuRetro)this.leJeu).Notice = notice;
            ((JeuRetro)this.leJeu).Etat = et;
            leJeu.Img = this.ph;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
