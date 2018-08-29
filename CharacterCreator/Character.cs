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
    class Character : ISerializable
    {
        private string name = "unnamed character";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Spritesheet spritesheet;
        public Spritesheet Spritesheet { get; set; } = null;
        

        private List<Layer> layers = new List<Layer>();
        public List<Layer> Layers
        {
            get { return layers; }
        }

        public Character(string name, Spritesheet spritesheet)
        {
            this.name = name;
            Spritesheet = spritesheet;
        }

        // The special constructor is used to deserialize values.
        public Character(SerializationInfo info, StreamingContext context)
        {
            // Reset the propert value using the GetValue method
            Name = (string)info.GetValue("name", typeof(string));
            Spritesheet = (Spritesheet)info.GetValue("spritesheet", typeof(Spritesheet));

            int count = (int)info.GetValue("layerCount", typeof(int));
            for (int i = 0; i < count; i++)
            {
                Layer layer = (Layer)info.GetValue("Layer_" + i, typeof(Layer));
                layers.Add(layer);
            }
        }

        // This method is called on serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values
            info.AddValue("name", Name, typeof(string));
            info.AddValue("spritesheet", Spritesheet, typeof(Spritesheet));
            info.AddValue("layerCount", layers.Count, typeof(int));
            for (int i = 0; i<layers.Count; i++)
            {
                info.AddValue("layer_" + i, layers[i], typeof(Layer));
            }
        }

        public void AddLayer(Layer layer)
        {
            layers.Add(layer);
        }

        public override string ToString()
        {
            return base.ToString() + "\n\tpath: \t" + spritesheet.ToString() +
            "\n\ttile coordinates: \t" + layers[0].TileCoordinates.ToString();


        }

    }
}



