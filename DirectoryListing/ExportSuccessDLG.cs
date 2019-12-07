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
    public partial class ExportSuccessDLG : Form
    {
        public ExportSuccessDLG()
        {
            InitializeComponent();
        }

        private void okBtnExportSuccessDLG_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportSuccessDLG_Load(object sender, EventArgs e)
        {
            lblExportSuccessDLG.Text = "Exporting directories to file is successful";
        }
    }
}
