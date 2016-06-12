using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wojna
{
    //class definig whole deck (all cards)
    //creating object of table automatically generates whole deck
    class Table
    {
        public List<Card> Deck = new List<Card>();

        public Table()
        {
            this.AddCards();
        }

        public void AddCards()
        {
            foreach (var type in Enum.GetValues(typeof(color))) //4 colors / sign of cards
            {
                for (int i = 1; i <= 13; i++) //13 cards per color
                {
                    string cardName = i.ToString() + "_" + type.ToString(); //name of card
                    Uri imageSourcePath = new Uri("pack://siteoforigin:,,,/Resources/" + cardName + ".png"); //path to resource with every card
                    Deck.Add(new Card(cardName, type.ToString(), i, imageSourcePath)); //adding card to deck
                }
            }
        }
    }

    //enum contains every color / sign of cards (4 possible options)
    public enum color
    {
        kier,
        karo,
        trefl,
        pik,
    }
}
