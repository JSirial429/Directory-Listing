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
    public partial class HelpDLGForm : Form
    {
        public HelpDLGForm()
        {
            InitializeComponent();
        }

        private void HelpDLGForm_Load(object sender, EventArgs e)
        {
            helpLabelDLG.Text = "To explore a directory please select a drive letter from the dropdown menu" +
                " above. After choosing a drive letter search the directory tree by using the left pane. Clicking on a directory reveals sub directories, if applicable." +
                "The contents of a particular directory is shown on the right.\n Once you are certain you want to print the directory illustrated click on the" +
                "print button.";
        }

        private void okHelpDLGBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
