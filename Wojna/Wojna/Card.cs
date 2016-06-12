using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna
{
    //class defines variables that every Card object must have
    //name of card = used to generate path and comfortable debugging
    //color - sign of every card (karo, pik, trefl, kier)
    //number - generated automatically, ace: 1, 2 - 10: normal numbers 2 - 10
    //jack: 11, queen: 12, king: 13
    //sourcePath used for displaying images in image objects in wpf
    class Card
    {
        public string name { get; private set; }

        public string color { get; private set; }

        public int number { get; private set; }

        public Uri imageSourcePath { get; private set; }

        public Card(string name, string color, int number, Uri imageSourcePath)
        {
            this.name = name;
            this.color = color;
            this.number = number;
            this.imageSourcePath = imageSourcePath;
        }
    }
}
