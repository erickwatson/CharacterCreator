using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace CharacterCreator
{
    [Serializable]
    class Layer : ISerializable
    {
        //private string name = string.Empty;
        public string Name { get; set; }

        //private Point tileCoordinates = new Point(0, 0);
        public Point TileCoordinates { get; set; }
        
        //private int priority = 0;
        public int Priority { get; set; }

        public Layer(string name)
        {
            Name = name;

        }

        public Layer(string name, Point coordinates)
        {
            Name = name;

            TileCoordinates = coordinates;
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem item = new ListViewItem(Name);
            item.SubItems.Add(Priority.ToString());
            item.SubItems.Add(TileCoordinates.X.ToString());
            item.SubItems.Add(TileCoordinates.Y.ToString());

            return item;
        }

        // The special constructor is used to deserialize values
        public Layer(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method
            Name = (string)info.GetValue("name", typeof(string));
            Priority = (int)info.GetValue("priority", typeof(int));

            Point tile = new Point();
            tile.X = (int)info.GetValue("tilex", typeof(int));
            tile.Y = (int)info.GetValue("tiley", typeof(int));
            TileCoordinates = tile;
        }

        // The method is called on serialization
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serializaed values
            info.AddValue("name", Name, typeof(string));
            info.AddValue("priority", Priority, typeof(int));
            info.AddValue("tilex", TileCoordinates.X, typeof(int));
            info.AddValue("tiley", TileCoordinates.Y, typeof(int));            
        }




    }
}
