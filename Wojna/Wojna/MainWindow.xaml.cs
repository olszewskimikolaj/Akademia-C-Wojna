using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wojna
{
    /// <summary>
    /// Main game loop ang logic class
    /// </summary>
    public partial class MainWindow : Window
    {
        //bot object
        ComputerPlayer computer { get; set; }

        //player object
        Player player { get; set; }

        //table, deck object
        Table table { get; set; }

        //random object
        Random random = new Random();

        //private bool variables and pot list are used in case of war
        //war - two cards with the same weight (number)
        //shirt - while war starts two cards with the same number lay on table
        //then both players have to lay next card upside-down on laid cards
        //now we have covered lower cards with higher cards with shirt (backside) on top
        //shirt variable is for checking if cards while war are first layed cards
        //or they are covered with new cards
        private bool war = false;
        private bool shirt = false;
        private List<Card> pot = new List<Card>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //on program start we see main menu panel with textboxes to set name etc. and "Graj" GameButton
        //in case of clicking this button program starts game with a few operations
        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            war = false; //reset war variable to default (false) in case when newgame button was clicked while war
            computer = null;
            computer = new ComputerPlayer("Alan"); //reset computer object and set new for new game
            HideMainMenu(); //hide main menu with all textboxes
            SetUserName(); //reset and create new player object with specified name etc.
            ShowGameTable();
            CreateNemGame();
        }

        //main menu objects properties visibility set to hidden
        private void HideMainMenu()
        {
            
            FirstNameBox.Visibility = Visibility.Hidden;
            SecondNameBox.Visibility = Visibility.Hidden;
            NickBox.Visibility = Visibility.Hidden;
            FirstNameLabel.Visibility = Visibility.Hidden;
            SecondNameLabel.Visibility = Visibility.Hidden;
            NickLabel.Visibility = Visibility.Hidden;
            GameButton.Visibility = Visibility.Hidden;
            WojnaLabel.Visibility = Visibility.Hidden;
        }

        //reset and create new player object with specified name etc.
        private void SetUserName()
        {
            string firstName, secondName, nick;
            firstName = FirstNameBox.Text.ToString();
            secondName = SecondNameBox.Text.ToString();
            nick = NickBox.Text.ToString();
            player = null;
            player = new Player(firstName, secondName, nick);
        }

        //set all game objects properties visibility to visible
        private void ShowGameTable()
        {
            //labels
            ComputerNameLabel.Content = computer.computerName;
            ComputerNameLabel.Visibility = Visibility.Visible;
            PlayerNameLabel.Content = player.name; //set player name
            PlayerNameLabel.Visibility = Visibility.Visible;
            ComputerCardsLabel.Visibility = Visibility.Visible;
            PlayerCardsLabel.Visibility = Visibility.Visible;
            NoComputerCardsLabel.Visibility = Visibility.Visible;
            NoPlayerCardsLabel.Visibility = Visibility.Visible;

            //images used to display cards
            ComputerPlayerCardsImage.Visibility = Visibility.Visible;
            PlayerCardsImage.Visibility = Visibility.Visible;
            LaidComputerPlayerCardImage.Visibility = Visibility.Visible;
            LaidPlayerCardImage.Visibility = Visibility.Visible;

            //info button
            InfoButton.Visibility = Visibility.Visible;

        }

        //creates new game, defines new table (deck), gives cards to players and displays shirts of cards as cards on stack
        private void CreateNemGame()
        {
            table = new Table();
            GiveAwayCards();
            ReadCardsImages();
        }

        //method gives random cards from deck to both users
        //and displays on game panel number of cards every player has
        //cards that are beeing laid on table are last cards from each player cards list
        //if player win - won cards are beeing added to the beginning of each list
        private void GiveAwayCards()
        {
            while (table.Deck.Count != 0)
            {
                int cardToGiveAway = random.Next(table.Deck.Count - 1);
                var card = table.Deck[cardToGiveAway];
                player.Cards.Add(card);
                table.Deck.RemoveAt(cardToGiveAway);

                cardToGiveAway = random.Next(table.Deck.Count - 1);
                card = table.Deck[cardToGiveAway];
                computer.Cards.Add(card);
                table.Deck.RemoveAt(cardToGiveAway);
            }
            NoComputerCardsLabel.Content = computer.Cards.Count;
            NoPlayerCardsLabel.Content = player.Cards.Count;

        }

        //method displays default shirts of cards as cards on stack
        private void ReadCardsImages()
        {
            ComputerPlayerCardsImage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/wzor.png"));
            PlayerCardsImage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/wzor.png"));
        }

        //in case game has started and player wants to start new game
        //there is new game button that moves player to main menu panel
        //and reset all variables set till button click time
        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            HideGameTable();
            OverridePlayersAndShowMainMenu();
        }
        
        //hide game table (game panel), set all fields to hidden
        //and image objects sources to null
        private void HideGameTable()
        {
            //labels
            ComputerNameLabel.Visibility = Visibility.Hidden;
            PlayerNameLabel.Visibility = Visibility.Hidden;
            ComputerCardsLabel.Visibility = Visibility.Hidden;
            PlayerCardsLabel.Visibility = Visibility.Hidden;
            NoComputerCardsLabel.Visibility = Visibility.Hidden;
            NoPlayerCardsLabel.Visibility = Visibility.Hidden;

            //images
            ComputerPlayerCardsImage.Visibility = Visibility.Hidden;
            PlayerCardsImage.Visibility = Visibility.Hidden;
            LaidComputerPlayerCardImage.Visibility = Visibility.Hidden;
            LaidPlayerCardImage.Visibility = Visibility.Hidden;
            ComputerPlayerCardsImage.Source = null;
            PlayerCardsImage.Source = null;
            LaidPlayerCardImage.Source = null;
            LaidComputerPlayerCardImage.Source = null;


            InfoButton.Visibility = Visibility.Hidden;
        }
        
        //set all variables and objects to null / false (default)
        //show all main menu objects to start new game
        private void OverridePlayersAndShowMainMenu()
        {
            computer = null;
            player = null;
            war = false;
            shirt = false;
            FirstNameBox.Visibility = Visibility.Visible;
            FirstNameBox.Text = "";
            SecondNameBox.Visibility = Visibility.Visible;
            SecondNameBox.Text = "";
            NickBox.Visibility = Visibility.Visible;
            NickBox.Text = "";
            FirstNameLabel.Visibility = Visibility.Visible;
            SecondNameLabel.Visibility = Visibility.Visible;
            NickLabel.Visibility = Visibility.Visible;
            GameButton.Visibility = Visibility.Visible;
            WojnaLabel.Visibility = Visibility.Visible;
        }

        //on game table (game panel) click on players cards (card stack) calls this method
        //first click - lay cards
        //second click - get or give cards to computer
        private void LayCards(object sender, MouseButtonEventArgs e)
        {
            if(player.Cards.Count != 0 || computer.Cards.Count != 0)//if both players (player and computer) still have cards
            {
                PlayGame(); //game is played
            }
            else if(player.Cards.Count == 52) //if player have all cards
            {
                player.Win(); //player wins
                HideGameTable(); //game panel is beeing hidden
                OverridePlayersAndShowMainMenu(); //game is beeing reset
            }
            else if (computer.Cards.Count == 52) //if computer have all cards
            {
                computer.Win(); //computer wins
                HideGameTable(); //game panel is beeing hidden
                OverridePlayersAndShowMainMenu(); //game is beeing reset
            }
        }

        //main game loop / logic
        private void PlayGame()
        {
            if (LaidPlayerCardImage.Source == null)//if no card is displayed -> no card has been laid on table, this is "first click"
            {
                LaidPlayerCardImage.Source = new BitmapImage(player.Cards.Last().imageSourcePath); //display last cards from both players
                LaidComputerPlayerCardImage.Source = new BitmapImage(computer.Cards.Last().imageSourcePath);
                if (player.Cards.Last().number == computer.Cards.Last().number) //if cards have the same number
                {
                    war = true; //war starts, bool set to true
                }
                shirt = false; //we dont cover cards in this move
            }
            else//if any cards are displayed on table, "second click" after laying cards
            {
                if (war) //if we continue war
                {
                    WarLogic(); //we use war logic that tells what to do
                }
                else //if war is ended or laid cards didn't start war
                {
                    GameLogic(); //we use normal game logic with stronger card
                    LaidPlayerCardImage.Source = null; //reset images sources, nothing shows as no card were laid on table
                    LaidComputerPlayerCardImage.Source = null; //same as above
                }
            }
        }

        //if war started
        private void WarLogic()
        {
            if(shirt == false) //if laid cards are first card on war (no shirt-up cards)
            {
                LaidPlayerCardImage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/wzor.png")); //both players lay cards upside-down (shirt-up)
                LaidComputerPlayerCardImage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/wzor.png")); //same as above

                AddWarCardsToPot(); //cards laid on table are added to template pot (2 last cards from both players cards lists)

                shirt = true; //variable shirt is set to true because higher cards are laying upside-down
            }
            else //if cards lays upside-down
            {
                LaidPlayerCardImage.Source = new BitmapImage(player.Cards.Last().imageSourcePath); //lay new war card on top of laid upside-down card
                LaidComputerPlayerCardImage.Source = new BitmapImage(computer.Cards.Last().imageSourcePath); //same as above for other player
                shirt = false; //reset variables
                war = false;
                if (player.Cards.Last().number == computer.Cards.Last().number) //if next laid cards perform another war
                {
                    war = true; //set another war
                    PlayGame(); //play game
                }
                else //if next laid cards don't peform another war
                {
                    GameLogic(); //play as normal game logic
                }
            }
        }

        //method takes 2 last cards from both players and adds it to template pot
        private void AddWarCardsToPot()
        {
            var card = player.Cards.Last(); //choose last, add last, remove last + choose last, add last, remove last = choose, add and remove 2 lasts cards
            pot.Add(card);
            player.Cards.RemoveAt(player.Cards.Count - 1);
            card = player.Cards.Last();
            pot.Add(card);
            player.Cards.RemoveAt(player.Cards.Count - 1);

            card = computer.Cards.Last();
            pot.Add(card);
            computer.Cards.RemoveAt(computer.Cards.Count - 1);
            card = computer.Cards.Last();
            pot.Add(card);
            computer.Cards.RemoveAt(computer.Cards.Count - 1);
        }

        //normal game logic telling which card is "stronger"
        private void GameLogic()
        {
            //ace beats all, other cards as its numbers - higher number card beats lower number cards
            if(player.Cards.Last().number == 1 && computer.Cards.Last().number != 1) //if player laid ace
            {
                GiveCardsToPlayer(); //called method giving won cards to player
            }
            else if(player.Cards.Last().number == 1 && computer.Cards.Last().number == 1) //if computer laid ace
            {
                GiveCardsToComputer(); //called method giving won cards to computer
            }
            else if(player.Cards.Last().number > computer.Cards.Last().number) //if player laid stronger card
            {
                GiveCardsToPlayer();
            }
            else if(player.Cards.Last().number < computer.Cards.Last().number) //if computer laid stronger card
            {
                GiveCardsToComputer();
            }
        }

        //method gives cards from player and pot to computer
        private void GiveCardsToComputer()
        {
            var card = player.Cards.Last(); //choose last player card
            computer.Cards.Insert(0, card); //insert it to computer list at first place
            player.Cards.RemoveAt(player.Cards.Count - 1); //remove card from player list

            card = computer.Cards.Last(); //choose last computer card
            computer.Cards.Insert(0, card); //insert it to computer first place
            computer.Cards.RemoveAt(computer.Cards.Count - 1); //remove last card from computer list
            if (pot.Any()) //if pot contain any card (after war)
            {
                foreach (var potCard in pot) 
                {
                    computer.Cards.Insert(0, potCard); //each card insert to first position in computer list
                }
                pot.Clear(); //clear pot
            }
            NoComputerCardsLabel.Content = computer.Cards.Count; //refresh number of computer cards
            NoPlayerCardsLabel.Content = player.Cards.Count; //refresh number of player cards
        }

        //method gives cards from computer and pot to player
        private void GiveCardsToPlayer()
        {
            var card = player.Cards.Last(); //choose last player card
            player.Cards.Insert(0, card); //insert it to player list at first place
            player.Cards.RemoveAt(player.Cards.Count - 1); //remove card from player list

            card = computer.Cards.Last(); //choose last computer card
            player.Cards.Insert(0, card); //insert it to player first place
            computer.Cards.RemoveAt(computer.Cards.Count - 1); //remove last card from computer list
            if (pot.Any()) //if pot contain any card (after war)
            {
                foreach (var potCard in pot)
                {
                    player.Cards.Insert(0, potCard); //each card insert to first position in player list
                }
                pot.Clear(); //clear pot
            }
            NoComputerCardsLabel.Content = computer.Cards.Count; //refresh number of computer cards
            NoPlayerCardsLabel.Content = player.Cards.Count; //refresh number of player cards
        }

        //information button click, button is displayed on game panel in right upper corner
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aby wyłożyć lub zebrać karty kliknij na swój stos kart.");
        }
    }
}
