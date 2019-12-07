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
    public partial class dirFilError : Form
    {
        public dirFilError()
        {
            InitializeComponent();
        }

        private void btnErrOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dirFilError_Load(object sender, EventArgs e)
        {
            
        }

        public void errMessage(String errMssg)
        {
            errLabel.Text = errMssg + "\nhas encountered an error due to Access Unauthorized exception.";
        }
    }
}
