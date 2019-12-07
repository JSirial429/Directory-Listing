using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Drawing.Printing;
using System.Management;
using System.Runtime;

namespace DirectoryListing
{

    public partial class MainMenuDL : Form
    {
        private string directoryPath = ""; //Stores path of directory once chosen by user 
        private ArrayList dirList = new ArrayList();     //EXPERIMENTAL
        //private String filePath= "C:\\Users\\jorges\\Desktop\\Directories.txt";  //EXPERIMENTAL C:\\Users\\jorges\\Desktop\\Directories.txt
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        //private PrintDocument printDocument1 = new PrintDocument();
        private string documentContents;//Variable that holds contents of document EXPERIMENTAL
        private string stringToPrint;//Variable to hold the portion fo the document that is not printed EXPERIMENTAL
        StreamWriter wf;
        String[] cboxDrives; //Holds an array of drives on the computer that will be used in the combo box
        //GCLatencyMode lessIntrusive = GCSettings.LatencyMode; //2ND PHASE DEBUGGING

        /// <summary> 3RD PHASE DEBUGGING USED IN POPULATEARRAYLIST()
        //private string literalDesktopDirTextPath = "\\Desktop\\Directories.txt";
        //private string literalUsersPath = "C:\\Users\\";
        //private string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        private string filePath = "";
        /// <summary>3RD PHASE DEBUGGING USED IN POPULATEARRAYLIST()
        public MainMenuDL()
        {
            InitializeComponent();
            ListDrives();  //2ND PHASE DEBUG
            //PopulateTreeView(); //2ND PHASE DEBUG
            this.treeView2.NodeMouseClick +=
            new TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
            DirectoryPathLabel.Text = "";
            exportFileBtn.Visible = false;//HIDES EXPORT BUTTON DURING RUNTIME MIGHT ENABLE IN FUTURE
            exportToolStripMenu.Visible = false;//HIDES EXPORT MENU OPTION DURING RUNTIME MIGHT ENABLE IN FUTURE
            progressBar1.Visible = false; //2ND PHASE DEBUG

        }

        private void MainMenuDL_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            //PopulateTreeView();  //2ND PHASE DEBUG
            this.treeView2.NodeMouseClick +=
            new TreeNodeMouseClickEventHandler(this.treeView2_NodeMouseClick);
            DirectoryPathLabel.Text = "";
            exportFileBtn.Visible = false;//HIDES EXPORT BUTTON DURING RUNTIME MIGHT ENABLE IN FUTURE
            ListDrives();  //2ND PHASE DEBUG

        }

        private void PopulateTreeView(string aString)
        {
            treeView2.Nodes.Clear(); //2nd Phase Debug

            TreeNode rootNode;

            populateTreeViewProgress(aString);  //2ND PHASE DEBUGGING

            //2nd Phase Debugging Below
            //DriveInfo[] mappedDrives = DriveInfo.GetDrives(); //Gathers all mapped drives on the current computer

            //2nd Phase Debugging Below
            //foreach(DriveInfo drive in mappedDrives)
            //{//2nd Phase Debugging below
            DirectoryInfo info = new DirectoryInfo(aString);  //Instantiating a new instance of directoryinfo with 
                                                              //Hard code Mike's directory path

            if (info.Exists)  //True if directory exists.
            {

                rootNode = new TreeNode(info.Name); //rootnode is instantiated with the name of directory

                rootNode.Tag = info;  //rootnode sets/gets the object by directory info 
                GetDirectories(info.GetDirectories(), rootNode);  //Calls helper method below 
                treeView2.Nodes.Add(rootNode);

            }
            //}

            //populateTreeViewProgress(aString);  //2ND PHASE DEBUGGING
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;

            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir; //rootnode sets/gets the object by directory info 
                aNode.ImageKey = "folder";

                try
                {
                    subSubDirs = subDir.GetDirectories(); //Might need to write a try catch block for unauthorized access
                    if (subSubDirs.Length != 0)
                    {
                        GetDirectories(subSubDirs, aNode); //Recursion 
                    }
                    nodeToAddTo.Nodes.Add(aNode);
                }
                catch (UnauthorizedAccessException e)
                {
                    //dirFilError dlg = new dirFilError();
                    //dlg.errMessage(e.ToString());
                    //dlg.ShowDialog();
                }
                catch (DirectoryNotFoundException e)
                {

                }
                catch (IOException e)
                {

                }

                StepProgressBar(); //2ND PHASE DEBUG MOVES THE PROGRESS BAR NEEDLE
            }

            //Progress Bar appears when done populating directory tree
            progressBar1.Visible = false;
        }

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            TreeNode newSelected = e.Node;  //Node selected on the win form is passed to newSelected TreeNode object
            listView2.Items.Clear();  //Prevents list view from appending items each time a user clicks a new dir
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;  //Currently Selected Node casted to Directory Info

            directoryPath = nodeDirInfo.FullName;//EXPERIMENTAL---------------------------------------------------
            DirectoryPathLabel.Text = directoryPath; //EXPERIMENTAL-----------------------------------------------


            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;

            foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
            {
                item = new ListViewItem(dir.Name, 0); //Initializing a new instance of ListViewItem class
                                                      //with the specified item text and the image index position of the item's icon.
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "Directory"),//Initializes a new ListViewSubItem object
                                                                          //The string argument is what shows
                                                                          //up in the list view control
                      new ListViewItem.ListViewSubItem(item,
                      dir.LastAccessTime.ToShortDateString())
                    };

                item.SubItems.AddRange(subItems);
                listView2.Items.Add(item);

                //dirContent = dir.Name.ToString(); //EXPERIMENTAL
                //Export2File(dirContent, filePath); //EXPERIMENTAL
            }
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                item = new ListViewItem(file.Name, 1);
                subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"),//The string argument is what shows up in the
                                                                     //list view control
                      new ListViewItem.ListViewSubItem(item,
                      file.LastAccessTime.ToShortDateString())
                    };

                item.SubItems.AddRange(subItems);
                listView2.Items.Add(item);

                //FileContent = file.Name.ToString(); //EXPERIMENTAL
                //Export2File(FileContent, filePath); //EXPERIMENTAL
            }

            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportToolStripMenu_Click(object sender, EventArgs e)
        {
            populateArrayList();
        }

        //Helper method that stores a file with the directories written to it that is critical for the 
        //prinitng function
        private void Export2File(ArrayList inputList, String inputFilePath)  //EXPERIMENTAL
        {
            string newString = "";
            string newPath = "";
            FileAttributes attributes;

            //wf = File.AppendText(inputFilePath);  //Append text instead of overwriting it EXPERIMENTAL
            wf = new StreamWriter(inputFilePath);  //Might need to use this for printing
            //wf.WriteLine("-----------------------" + DateTime.Now.ToString() + "-----------------------\n");
            wf.WriteLine(DirectoryPathLabel.Text.ToString()); //EXPERIMENTAL
            wf.WriteLine("\n");
            foreach (string input in inputList)
            {
                /////////////3RD PHASE////////////////////////////
                newPath = directoryPath + "\\" + input;
                attributes = File.GetAttributes(newPath);
                /////////////////////////////////////////////////
                // input.Contains(".") Was used below in the if statement 2ND PHASE DEBUG

                if (attributes == FileAttributes.Directory)// If the string contains a punction mark then it must be a file
                {

                    //wf.WriteLine(String.Format("{0,-60} {1,11}", input, "File"));//newString = input + "                  "+"File";

                    //wf.Write(String.Format("{0,-50}",input));
                    //wf.Write(String.Format("{0,10}", "File"));
                    wf.WriteLine(input + " - DIRECTORY");
                }
                else
                {

                    //wf.WriteLine(String.Format("{0,-60} {1,10}", input, "Directory"));//newString = input + "                  "+"Directory";
                    //wf.Write(String.Format("{0,-50}", input));
                    //wf.Write(String.Format("{0,10}", "Directory"));
                    wf.WriteLine(input + " - FILE");
                }

                wf.WriteLine(newString);                                     //EXPERIMENTAL

                newPath = directoryPath;
            }

            wf.WriteLine("-----------------------" + DateTime.Now.ToString() + "-----------------------\n");

            wf.Close();                                                    //EXPERIMENTAL

            //Calls other form to indicate to user that export to file has been successful
            ExportSuccessDLG dlg = new ExportSuccessDLG();
            //dlg.ShowDialog(); NOT NEEDED SINCE THE EXPORT BUTTON IS DISABLED DURING RUN TIME

        }

        //populateArrayList method gathers items in the list view collection and adds them to an array list
        private void populateArrayList()                                  //EXPERIMENTAL
        {

            //This ensures that every time the user chooses a new directory on the left pane then the arraylist
            //is cleared and is updated with the new set of items in the Listview collection
            if (dirList.Count >= 1)
            {
                dirList.Clear();
            }
            //Appends all the recent items in collection to the array list
            foreach (ListViewItem items in listView2.Items)
            {

                dirList.Add(items.Text);


            }

            //STORES THE CURRENT USER PROFIULE ON THE PC INTO STRING
            //userName = userName.Substring(7);
            //CONCATENATES THE FILE PATH OF THE CURRENT USER'S DESKTOP
            //filePath = literalUsersPath + userName + literalDesktopDirTextPath;//3RD PHASE DEBUGGING

            filePath = getCurrentUserDektopPath();

            //Calls helper method to store a file with the selected directory 
            Export2File(dirList, filePath);

        }

        private void exportFileBtn_Click(object sender, EventArgs e)
        {

            populateArrayList();

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDLGForm dlg = new HelpDLGForm();
            dlg.ShowDialog();
        }

        //Method that reads the document to be printed. Must follow the same path as export2File method
        private void ReadDocument()
        {
            //string docName = "Directories.txt";
            //string docPath = @"C:\\Users\\jorges\\Desktop\\";
            //printDocument2.DocumentName = docName;
            printDocument2.DocumentName = filePath;
            //using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }


        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {

            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;

            //string text = DirectoryPathLabel.Text.ToString() + "\n\n";

            //if (dirList.Count >= 1)
            //{
            //    dirList.Clear();
            //}
            ////Appends all the recent items in collection to the array list
            //foreach (ListViewItem items in listView2.Items)
            //{

            //    dirList.Add(items.Text);


            //}

            //foreach(string dirFil in dirList)
            //{
            //    if(dirFil.Contains("."))
            //    {
            //        text = text + dirFil + " - File\n";
            //    }
            //    else
            //    {
            //        text = text + dirFil + " - Directory\n";
            //    }

            //}

            //text = text + "\n-----------------------" + DateTime.Now.ToString() + "-----------------------\n";
            ////System.Drawing.Font printFont = new System.Drawing.Font
            ////    ("Arial", 18, System.Drawing.FontStyle.Regular);

            //// Sets the value of charactersOnPage to the number of characters 
            //// of stringToPrint that will fit within the bounds of the page.
            //e.Graphics.MeasureString(text, this.Font,
            //    e.MarginBounds.Size, StringFormat.GenericTypographic,
            //    out charactersOnPage, out linesPerPage);

            //// Draws the string within the bounds of the page.
            //e.Graphics.DrawString(text, this.Font, Brushes.Black,
            //e.MarginBounds, StringFormat.GenericTypographic);

            //// Remove the portion of the string that has been printed.
            //text = text.Substring(charactersOnPage);

            //// Check to see if more pages are to be printed.
            //e.HasMorePages = (text.Length > 0);

            //// If there are no more pages, reset the string to be printed.
            //if (!e.HasMorePages)
            //    text = documentContents;


        }
        //Opens the print preview dialog that allows the user to print
        private void printStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Calls Helper Method
            populateArrayList();

            ReadDocument();
            printPreviewDialog2.Document = printDocument2;
            printPreviewDialog2.ShowDialog();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {

            if (listView2.Items.Count == 0)
            {
                NoDir2Print newDlg = new NoDir2Print();
                newDlg.ShowDialog();
            }
            else
            {
                PrintDialog printDialog1 = new PrintDialog();

                //Calls the helper method 
                populateArrayList();  //TESTING NEW PRINT DIALOG THAT ALLOWS NOT PRINTING TEXT FILE(Disregard)

                ReadDocument();       //TESTING NEW PRINT DIALOG THAT ALLOWS NOT PRINTING TEXT FILE(Disregard)

                printDialog1.AllowSomePages = true;
                printDialog1.ShowHelp = true;
                printDialog1.Document = printDocument2;
                DialogResult result = printDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument2.Print();
                }
                //printPreviewDialog2.Document = printDocument2;
                //printPreviewDialog2.ShowDialog();
            }

            //PrintDialog printDialog1 = new PrintDialog();

            //Calls the helper method
            //populateArrayList();  //TESTING NEW PRINT DIALOG THAT ALLOWS NOT PRINTING TEXT FILE(Disregard)

            //ReadDocument();       //TESTING NEW PRINT DIALOG THAT ALLOWS NOT PRINTING TEXT FILE(Disregard)

            //printDialog1.AllowSomePages = true;
            //printDialog1.ShowHelp = true;
            //printDialog1.Document = printDocument2;
            //DialogResult result = printDialog1.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    printDocument2.Print();
            //}
            //printPreviewDialog2.Document = printDocument2;
            //printPreviewDialog2.ShowDialog();

        }

        //USED IN THE DROPDOWN TO SHOW CURRENT DRIVES ON COMPUTER
        private void ListDrives()//2ND PHASE DEBUG
        {

            cboxDrives = Directory.GetLogicalDrives();

            foreach (string listedDrv in cboxDrives)
            {
                DirectoryInfo dir = new DirectoryInfo(listedDrv);

                if (dir.Exists)
                {
                    menuCBOX.Items.Add(listedDrv);
                }

            }

            //menuCBOX.SelectedIndex = 0;

        }//2ND PHASE DEBUG

        //2ND PHASE DEBUG This method
        private void menuCBOX_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedObj = menuCBOX.SelectedItem.ToString();
            PopulateTreeView(selectedObj);
        }

        //Helper method called from 2ND PHASE DEBUGGING
        private void populateTreeViewProgress(string aString)
        {
            ////Progress Bar appears when populating directory tree
            //progressBar1.Visible = true;

            //progressBar1.Minimum = 1;

            //progressBar1.Maximum = Directory.EnumerateDirectories(aString).Count();

            //progressBar1.Value = 1;

            //progressBar1.Step = 1;

            ////progressBar1.PerformStep();

            //progressBar1.Style

        }

        private void StepProgressBar()
        {
            progressBar1.PerformStep();
        }

        //Helper method used to locate text file to print. 
        private string getCurrentUserDektopPath()
        {

            string literalDesktopDirTextPath = "\\Desktop\\Directories.txt";
            string literalUsersPath = "C:\\Users\\";
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            userName = userName.Substring(7);
            string newDesktopPath = literalUsersPath + userName + literalDesktopDirTextPath;

            return newDesktopPath;

        }

    }

}
