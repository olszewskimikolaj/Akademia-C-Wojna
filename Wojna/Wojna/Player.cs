using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wojna
{
    //class defines player (user), player have its own name set accordind to what user put to textboxes
    //player have its own list of cards from which player throws cards on the table
    //player have its own method win() called in case of win
    class Player
    {
        public string name { get; private set; }

        public List<Card> Cards { get; set; }

        public Player(string firstName, string secondName, string nick)
        {
            //according to what is given on the input (textboxes) the same method is called with different arguments
            if (firstName == "" && secondName == "" && nick == "")
            {
                setUserName();
            }
            else if (firstName != "" && secondName == "" && nick == "")
            {
                setUserName(firstName);
            }
            else if (firstName != "" && secondName != "" && nick == "")
            {
                setUserName(firstName, secondName);
            }
            else
                setUserName(firstName, secondName, nick);

            //in every GameButton click constructor creates new object of player so as it creates new list of cards
            Cards = null;
            Cards = new List<Card>();
        }

        //methods setting name of player
        private void setUserName()
        {
            this.name = "Gracz";
        }

        private void setUserName(string firstName)
        {
            this.name = firstName;
        }

        private void setUserName(string firstName, string secondName)
        {
            this.name = firstName + " " + secondName;
        }

        private void setUserName(string firstName, string secondName, string nick)
        {
            this.name = firstName + " \"" + nick + "\" " + secondName;
        }

        public void Win()
        {
            MessageBox.Show("Wygrałeś, gratulacje!");
        }

    }
}
