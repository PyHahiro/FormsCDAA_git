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
    public partial class SupprimerDlg : Form
    {
        private LesJeux lj;
        public SupprimerDlg()
        {
            InitializeComponent();
        }

        public SupprimerDlg(LesJeux lesj)
        {
            InitializeComponent();
            this.lj = lesj;
            Initliste();
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Initliste()
        {
            Clear();
            foreach (Jeu j in lj.Listj)
            {
                listBox1.Items.Add(j.Nom);
            }
        }

        private void Clear()
        {
            listBox1.Items.Clear();
            pictureBox1.Image = null;
            richTextBox1.Text = "";
            listBox1.SelectedItem = null;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = lj.GetJeuNom((String)listBox1.SelectedItem).Img;
                richTextBox1.Text = lj.GetJeuNom((String)listBox1.SelectedItem).ToString();
            }
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                lj.DelJeu((String)listBox1.SelectedItem);
            }
            Initliste();
        }
    }
}
