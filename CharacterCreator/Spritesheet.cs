using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CharacterCreator
{
    public class Spritesheet
    {
        private Image image = null;
        
        public Image Image
        {
            get; private set;
        }

        public string Path { get; private set; }

        public int GridWidth { get; set; } = 16;

        public int GridHeight { get; set; } = 16;
        public int Spacing { get; set; } = 1;

        public string Filename
        {
            get { return Path.Substring(Path.LastIndexOf('\\')); }
        }
        



        private string path;
        public int Width { get { return (image != null) ? image.Width : 0; } }

        public int Height { get { return (image != null) ? image.Height : 0; } }

        public Spritesheet(string path)
        {
            //this.path = path;
            //Load();
            Path = path;
            Image = Image.FromFile(path);
        }

        public void Load()
        {
            image = Image.FromFile(@"J:\GITREPO\MathLibraryCLR\roguelikeChar_transparent.png");
        }

        public override string ToString()
        {
            return Filename;
        }

    }
}
