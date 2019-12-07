using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirectoryListing
{
    public partial class NoDir2Print : Form
    {
        public NoDir2Print()
        {
            InitializeComponent();
        }

        private void NoDir2Print_Load(object sender, EventArgs e)
        {
            lblNoDir2Print.Text = "There is no directory to print. Please choose \n a drive a letter and directory.";
        }

        private void okBtnNoDir2Print_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
