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
    public partial class ModifDlg : Form
    {
        public List<Jeu> lj;
        public ModifDlg()
        {
            InitializeComponent();
            lj = new List<Jeu>();
            initDataGrid();
        }
        public ModifDlg(LesJeux lj)
        {
            InitializeComponent();
            this.lj = lj.Listj;
            initDataGrid();
            button2.Text = "Valider";
            button1.Text = "Annuler";
        }
        public void initDataGrid()
        {
            ((DataGridViewImageColumn )dataGridView1.Columns[8]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            Etat.DataSource = Enum.GetValues(typeof(Etats));
            Genre.DataSource = Enum.GetValues(typeof(Genres));
            Nom.ReadOnly = true; 
            Description.ReadOnly = true; 
            Plateforme.ReadOnly = true; 
            Editeur.ReadOnly = true;
            DateSortie.ReadOnly = true;
            Reco.ReadOnly = true;
            Etat.ReadOnly = true;
            Notice.ReadOnly = true;
            for (int i = 0; i < lj.Count; i++)
            {
                Jeu j = lj[i];
                this.dataGridView1.Rows.Add(j.Nom, j.Description, j.Plateforme);
                this.dataGridView1.Rows[i].Cells[3].Value = j.Genre;
                this.dataGridView1.Rows[i].Cells[4].Value = j.Editeur;
                this.dataGridView1.Rows[i].Cells[5].Value = j.Prix;
                this.dataGridView1.Rows[i].Cells[6].Value = j.Date;

                if (j.Recondition)
                    this.dataGridView1.Rows[i].Cells[7].Value = true;


                this.dataGridView1.Rows[i].Cells[8].Value = j.Img;
                if (j is JeuRetro)
                {
                    this.dataGridView1.Rows[i].Cells[10].ReadOnly = false;
                    this.dataGridView1.Rows[i].Cells[11].ReadOnly = false;

                    this.dataGridView1.Rows[i].Cells[9].Value = true;
                    JeuRetro jr = (JeuRetro)j;
                    this.dataGridView1.Rows[i].Cells[10].Value = jr.Etat;
                    if (jr.Notice)
                        this.dataGridView1.Rows[i].Cells[11].Value = true;
                }
              
            }
        }


        private void ModifDlg_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 9)
            {


                if (dataGridView1.Rows[e.RowIndex].Cells[9].Value == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[10].ReadOnly = false;
                    dataGridView1.Rows[e.RowIndex].Cells[11].ReadOnly = false;
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[10].ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Cells[11].ReadOnly = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lj.Count; i++)
            {
                lj[i].Prix = double.Parse(this.dataGridView1.Rows[i].Cells[5].Value.ToString());
                String s = this.dataGridView1.Rows[i].Cells[3].Value.ToString();
                lj[i].Genre = (Genres)Enum.Parse(typeof(Genres), s);
                DataGridViewCheckBoxCell cell = this.dataGridView1.Rows[i].Cells[9] as DataGridViewCheckBoxCell;
                if (cell.Value != null)
                {
                    Console.WriteLine("true");
                    JeuRetro jr;
                    if (lj[i] is JeuRetro)
                    {
                        jr = (JeuRetro)lj[i];
                        if (dataGridView1.Rows[i].Cells[9].Value != null)
                        {

                            Jeu temp = new Jeu(jr.Nom, jr.Description, jr.Plateforme, jr.Genre, jr.Editeur, jr.Prix, jr.Date, jr.Recondition);
                            temp.Img = jr.Img;
                            lj[i] = temp;
                        }
                        else
                        {
                            jr.Etat = (Etats)Enum.Parse(typeof(Etats), this.dataGridView1.Rows[i].Cells[10].Value.ToString());
                            cell = this.dataGridView1.Rows[i].Cells[11] as DataGridViewCheckBoxCell;
                            if (cell.Value != null)
                                jr.Notice = true;
                            else
                                jr.Notice = false;
                        }
                        
                    }
                    else
                    {
                        jr = new JeuRetro(lj[i]);
                        if(this.dataGridView1.Rows[i].Cells[10].Value != null)
                            jr.Etat = (Etats)Enum.Parse(typeof(Etats), this.dataGridView1.Rows[i].Cells[10].Value.ToString());
                        else
                            jr.Etat = Etats.Inconnu;
                        cell = this.dataGridView1.Rows[i].Cells[11] as DataGridViewCheckBoxCell;
                        if (cell.Value != null)
                            jr.Notice = true;
                        else
                            jr.Notice = false;
                        lj[i] = jr;
                    }

                }
                this.DialogResult = DialogResult.OK;
                this.Close();
                //Vilain2
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
        }
    }
}
