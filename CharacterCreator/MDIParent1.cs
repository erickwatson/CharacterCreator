using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace CharacterCreator
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                SpriteForm childForm = new SpriteForm();

                // Use a BinaryFormatter or SoapFormatter
                IFormatter formatter = new SoapFormatter();
                childForm.DeserializeItem(FileName, formatter);

                // normally we would validate that the form loaded (as in didn't throw an exception)
                // before making it visible so we can cleanly exit on error

                // Check if the spritesheet form is open containing the same spritesheet, if not then open one
                SpriteSheetForm form = childForm.FindSheet();
                if (form == null)
                {
                    Form spritesheetForm = new SpriteSheetForm(childForm.Spritesheet);
                    spritesheetForm.MdiParent = this;
                    spritesheetForm.Text = "Sprite Sheet" + childFormNumber++;
                    spritesheetForm.Show();
                }
                else
                {
                    childForm.Spritesheet = form.Spritesheet;
                }

                // Finally, display thr SpriteForm
                childForm.MdiParent = this;
                childForm.Text = "Sprite " + childFormNumber++;
                childForm.Show();
            

            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void newSpriteSheet_Click(object sender, EventArgs e)
        {
            Form childForm = new SpriteSheetForm();
            childForm.MdiParent = this;
            childForm.Text = "Sprite Sheet" + childFormNumber++;
            childForm.Show();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                SpriteForm spriteForm = this.ActiveMdiChild as SpriteForm;
                if (spriteForm != null)
                {
                    //This is the name of the file holding the data
                    // You can use any file extension you like
                    string fileName = "dataStuff.myData";
                    // Use a BinaryFormatter or SoapFormatter
                    IFormatter formatter = new SoapFormatter();

                    spriteForm.SerializeItem(fileName, formatter);
                }
            }
        }

        private void toolStripMenuNewSprite_Click(object sender, EventArgs e)
        {
            Form childForm = new SpriteForm();
            childForm.MdiParent = this;
            childForm.Text = "Sprite" + childFormNumber++;
            childForm.Show();
        }
    }
}
