using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator
{
    public partial class MDIForm : Form
    {
        public MDIForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newMDIChild = new Form2();
            // Set the Parent Form of the Child Window
            newMDIChild.MdiParent = this;
            // Display the new form
            newMDIChild.Show();
        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine the active child form.
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control
            // which in this example, should be a RichTextBox.
            if (activeChild != null)
            {
                try
                {
                    TextBox theBox = (TextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Put the selected text on the Clipboard
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "Text File|*.txt";
                        dialog.FileName = "";
                        dialog.Title = "Save Text File";
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            string path = dialog.FileName;
                            File.WriteAllText(path, theBox.Text);
                            activeChild.Text = path;


                        }
                        

                    }
                }
                catch
                {
                    MessageBox.Show("You need to select a RichTextBox");
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine the active child form.
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control
            // which in this example, should be a RichTextBox.
            if (activeChild != null)
            {
                try
                {
                    TextBox theBox = (TextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Put the selected text on the Clipboard
                        Clipboard.SetDataObject(theBox.SelectedText);
                    }
                }
                catch
                {
                    MessageBox.Show("You need to select a TextBox");
                }
            }
        }

        private void closeWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine the active child form.
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control
            // which in this example, should be a RichTextBox.
            if (activeChild != null)
            {
                try
                {
                    TextBox theBox = (TextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Put the selected text on the Clipboard
                        activeChild.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Y U no close???");
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Determine the active child form
            Form activeChild = this.ActiveMdiChild;

            // If there is an active child form, find the active control
            // which in this example should be a RichTextBox
            if (activeChild != null)
            {
                try
                {
                    TextBox theBox = (TextBox)activeChild.ActiveControl;
                    if (theBox != null)
                    {
                        // Create a new instance of the DataObject interface
                        IDataObject data = Clipboard.GetDataObject();

                        // If the data is text, then set the text of the
                        // RichTextBox to the text in the clipboard
                        if (data.GetDataPresent(DataFormats.Text))
                        {
                            theBox.SelectedText = data.GetData(DataFormats.Text).ToString();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("You need to select a TextBox.");
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Make fileName as a working string
                string fileName = openFileDialog.FileName;
                
                // Create a new Form2
                Form2 newMDIChild = new Form2();

                // Set the Parent Form of the Child Window
                newMDIChild.MdiParent = this;
                
                // Display the new form
                newMDIChild.Show();

                // If the newMDIChild isn't null
                if (newMDIChild != null)
                {
                    try
                    {
                        // Calling the TextBox 'theBox'
                        TextBox theBox = (TextBox)newMDIChild.ActiveControl;
                        if (theBox != null)
                        {
                            // Reading the file using StreamReader
                            using (StreamReader read = new StreamReader(fileName))
                            {
                                newMDIChild.textBox1.Text = read.ReadToEnd();
                                
                            }
                            // set the title of the form to file path of the file
                            newMDIChild.Text = fileName;
                            
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Action Failed, check your code!");
                    }
                }
                
            }
        }
    }
}
