using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator
{
    public partial class SpriteForm : Form
    {
        Spritesheet spritesheet = null;
        Bitmap drawArea = null;
        public SpriteForm()
        {
            InitializeComponent();
            drawArea = new Bitmap(pictureBox.Width, pictureBox.Height);
        }
        private void SpriteForm_Activated(object sender, EventArgs e)
        {
            MdiClient parent = Parent as MdiClient;
            if (parent == null)
            {
                foreach(Form child in parent.MdiChildren)
                {
                    if(child.GetType() == typeof(SpriteForm))
                    {
                        SpriteSheetForm sheet = child as SpriteSheetForm;
                        Spritesheet ss = sheet.Spritesheet;
                        if (ss != null && !comboBoxSheets.Items.Contains(ss))
                        {
                            comboBoxSheets.Items.Add(ss);
                        }
                    }
                }
            }
            if(spritesheet != null)
            {
                comboBoxSheets.SelectedItem = spritesheet;
            }
            else if (comboBoxSheets.Items.Count > 0)
                {
                comboBoxSheets.SelectedIndex = 0;
                spritesheet = comboBoxSheets.SelectedItem as Spritesheet;
            }
        }
        private void SpriteForm_Load(object sender, EventArgs e)
        {

        }
    }
}
