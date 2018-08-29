using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace CharacterCreator
{
    [Serializable]
    public class Spritesheet : ISerializable
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
        

        // The special constructor is used to deserialize values
        public Spritesheet(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method
            Path = (string)info.GetValue("path", typeof(string));
            GridWidth = (int)info.GetValue("gridWidth", typeof(int));
            GridHeight = (int)info.GetValue("gridHeight", typeof(int));
            Spacing = (int)info.GetValue("spacing", typeof(int));
            Image = Image.FromFile(Path);
        }

        // The method is called on serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values
            info.AddValue("path", Path, typeof(string));
            info.AddValue("gridWidth", GridWidth, typeof(int));
            info.AddValue("gridHeight", GridHeight, typeof(int));
            info.AddValue("spacing", Spacing, typeof(int));
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
