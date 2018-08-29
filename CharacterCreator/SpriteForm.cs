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

        List<Layer> layers = new List<Layer>();
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
                    Layer layer = new Layer("Unnamed Layer");
                    layer.TileCoordinates = sheet.CurrentTile;
                    layer.Priority = layers.Count + 1;

                    layers.Add(layer);

                    listViewTiles.Items.Add(layer.GetListViewItem());

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

            foreach(Layer layer in layers)
            {
                Rectangle source = new Rectangle(
                    layer.TileCoordinates.X * (spritesheet.GridWidth + spritesheet.Spacing),
                    layer.TileCoordinates.Y * (spritesheet.GridHeight + spritesheet.Spacing),
                    spritesheet.GridWidth,
                    spritesheet.GridHeight);

                g.DrawImage(spritesheet.Image, dest, source, GraphicsUnit.Pixel);
            }
            g.Dispose();

            pictureBox.Image = drawArea;
        }



        private void comboBoxSheets_SelectedValueChanged(object sender, EventArgs e)
        {
            listViewTiles.Items.Clear();
            layers.Clear();

            spritesheet = comboBoxSheets.SelectedItem as Spritesheet;

            // clear the image
            Graphics g = Graphics.FromImage(drawArea);
            g.FillRectangle(Brushes.White, 0, 0, drawArea.Width, drawArea.Height);
            g.Dispose();
            pictureBox.Image = drawArea;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indicies =
                listViewTiles.SelectedIndices;
            if (indicies.Count <= 0)
                return;

            // remove the selected layers from the layers list
            layers.RemoveAt(indicies[0]);

            // delete and rebuild the list view (with updated priority values)
            listViewTiles.Items.Clear();

            // renumber layers
            for (int i=0; i<layers.Count; i++)
            {
                layers[i].Priority = i + 1;
                listViewTiles.Items.Add(layers[i].GetListViewItem());
            }

            DrawCharacter();
        }

        private void listViewTiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewTiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            int index = e.Item;
            layers[index].Name = e.Label;


        }
    }
}
