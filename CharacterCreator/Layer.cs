using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CharacterCreator
{
    class Layer
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


    }
}
