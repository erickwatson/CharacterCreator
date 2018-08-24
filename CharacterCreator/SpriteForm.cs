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
            if (parent != null)
            {
                foreach(Form child in parent.MdiChildren)
                {
                    if(child.GetType() == typeof(SpriteSheetForm))
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

        SpriteSheetForm FindSheet()
        {
            MdiClient parent = Parent as MdiClient;
            if (parent != null)
            {
                foreach (Form child in parent.MdiChildren)
                {
                    if (child.GetType() == typeof(SpriteSheetForm))
                    {
                        SpriteSheetForm sheet = child as SpriteSheetForm;
                        if (sheet.Spritesheet == spritesheet)
                            return sheet;
                    }
                }
            }
            return null;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (spritesheet!= null)
            {
                SpriteSheetForm sheet = FindSheet();
                if(sheet != null)
                {
                    listBoxTiles.Items.Add(sheet.CurrentTile);

                    DrawCharacter();
                }
            }
        }

        private void DrawCharacter()
        {
            Graphics g = Graphics.FromImage(drawArea);
            g.FillRectangle(Brushes.PapayaWhip, 0, 0, drawArea.Width, drawArea.Height);

            Rectangle dest = new Rectangle(0, 0,
                spritesheet.GridWidth << 2, spritesheet.GridHeight << 2);

            foreach(Point tile in listBoxTiles.Items)
            {
                Rectangle source = new Rectangle(
                    tile.X * (spritesheet.GridWidth + spritesheet.Spacing),
                    tile.Y * (spritesheet.GridHeight + spritesheet.Spacing),
                    spritesheet.GridWidth,
                    spritesheet.GridHeight);

                g.DrawImage(spritesheet.Image, dest, source, GraphicsUnit.Pixel);
            }
            g.Dispose();

            pictureBox.Image = drawArea;
        }



        private void comboBoxSheets_SelectedValueChanged(object sender, EventArgs e)
        {
            listBoxTiles.Items.Clear();
            spritesheet = comboBoxSheets.SelectedItem as Spritesheet;

            // clear the image
            Graphics g = Graphics.FromImage(drawArea);
            g.FillRectangle(Brushes.White, 0, 0, drawArea.Width, drawArea.Height);
            g.Dispose();
            pictureBox.Image = drawArea;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxTiles.SelectedIndex >= 0 &&
                listBoxTiles.SelectedIndex < listBoxTiles.Items.Count)
            {
                listBoxTiles.Items.RemoveAt(listBoxTiles.SelectedIndex);
                DrawCharacter();
            }

        }

        private void listBoxTiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
