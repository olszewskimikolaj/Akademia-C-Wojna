using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wojna
{
    //class defines computer player (bot), bot have its own name set from creating an object in MainWindow.xaml.cs
    //computer player have its own list of cards from which computer throws cards on the table
    //computer player have its own method win() called in case of win
    //class extends IComputerPlayer interface
    class ComputerPlayer : IComputerPlayer
    {
        public string computerName { get; set; }

        public List<Card> Cards { get; set; }

        public ComputerPlayer(string name)
        {
            this.computerName = name;

            //in every GameButton click constructor creates new object of player so as it creates new list of cards
            Cards = null;
            Cards = new List<Card>();
        }

        public void Win()
        {
            MessageBox.Show("Niestety, wygrał " + computerName +".");
        }
    }
}
