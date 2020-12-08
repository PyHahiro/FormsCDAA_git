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
    
    public partial class VisuJeuDlg : Form
    {
        private LesJeux lj;
        public LesJeux Lj { get { return lj; } set { lj = value; } }
        public VisuJeuDlg()
        {
            InitializeComponent();
        }
       
        public VisuJeuDlg(LesJeux lj)
        {
            InitializeComponent();
            this.Lj = lj;
            initArbre();
        }

        public void initArbre()
        {
            foreach(Genres cr in Enum.GetValues(typeof(Genres)))
            {
                TreeNode nd = new TreeNode(cr.ToString());
                LesJeux l = this.lj.GetJeuGenre(cr);
                foreach (Jeu j in l.Listj)
                {
                    TreeNode na = new TreeNode(j.Nom);
                    nd.Nodes.Add(na);
                }
                Arbre.Nodes.Add(nd);
            }
        }

        private void Arbre_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode nd = e.Node;
            if (nd.Level > 0)
            {
                Jeu j = this.lj.GetJeuNom(nd.Text);
                if (j != null)
                {
                    Edition.Text = j.ToString();
                    PBPhoto.Image = j.Img.GetThumbnailImage(PBPhoto.Width, PBPhoto.Height, null, IntPtr.Zero);
                }
            }
        }
    }
}
