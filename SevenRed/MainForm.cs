using SevenRedLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SevenRed
{


    public partial class MainForm : Form
    {
        Point lastPoint;

        List<Card> WhiteDeck;
        List<Card> BlackDeck;
        
        public MainForm()
        {
            InitializeComponent();
        }
                
        private void ClouseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void AddCards_Click(object sender, EventArgs e)
        {
            List<string> whiteDeck = WhiteDeckText.Lines.ToList();
            List<string> blackDeck = BlackDeckText.Lines.ToList();
            try
            {
                WhiteDeck = Service.ConvertListStringToListCard(whiteDeck);
                BlackDeck = Service.ConvertListStringToListCard(blackDeck);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            List<TextBox> WhiteSlot = new List<TextBox>(7) { whiteCard1, whiteCard2, whiteCard3, whiteCard4, whiteCard5, whiteCard6, whiteCard7};
            List<TextBox> BlackSlot = new List<TextBox>(7) { blackCard1, blackCard2, blackCard3, blackCard4, blackCard5, blackCard6, blackCard7};

            EnterCardsToWinForms(WhiteDeck, WhiteSlot);
            EnterCardsToWinForms(BlackDeck, BlackSlot);
        }

        private void EnterCardsToWinForms(List<Card> Deck, List<TextBox> Slot)
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                switch (Deck[i].Nominal)
                {
                    case 1:
                        Slot[i].Text = "1";
                        Slot[i].ForeColor = Color.White;
                        break;
                    case 2:
                        Slot[i].Text = "2";
                        Slot[i].ForeColor = Color.White;
                        break;
                    case 3:
                        Slot[i].Text = "3";
                        Slot[i].ForeColor = Color.White;
                        break;
                    case 4:
                        Slot[i].Text = "4";
                        Slot[i].ForeColor = Color.White;
                        break;
                    case 5:
                        Slot[i].Text = "5";
                        Slot[i].ForeColor = Color.White;
                        break;
                    case 6:
                        Slot[i].Text = "6";
                        Slot[i].ForeColor = Color.White;
                        break;
                    case 7:
                        Slot[i].Text = "7";
                        Slot[i].ForeColor = Color.White;
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < Deck.Count; i++)
            {
                switch (Deck[i].Color)
                {
                    case Colors.Red:
                        Slot[i].BackColor = Color.Red;
                        break;
                    case Colors.Orange:
                        Slot[i].BackColor = Color.Orange;
                        break;
                    case Colors.Yellow:
                        Slot[i].BackColor = Color.Yellow;
                        break;
                    case Colors.Green:
                        Slot[i].BackColor = Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(250)))), ((int)(((byte)(70)))));
                        break;
                    case Colors.LightBlue:
                        Slot[i].BackColor = Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
                        break;
                    case Colors.Blue:
                        Slot[i].BackColor = Color.Blue;
                        break;
                    case Colors.Purple:
                        Slot[i].BackColor = Color.Purple;
                        break;
                    default:
                        break;
                }
            }
        }

        private void FindAWinner_Click(object sender, EventArgs e)
        {
            if (WhiteDeck.Count != 0 && BlackDeck.Count != 0)
                MessageBox.Show(Service.FindWinner(WhiteDeck, BlackDeck));
            else if (BlackDeck.Count == 0 && WhiteDeck.Count == 0)
                MessageBox.Show("Enter cards");
            else if (WhiteDeck.Count == 0 && BlackDeck.Count != 0)
                MessageBox.Show("Black deck won");
            else
                MessageBox.Show("White deck won");
        }
    }
}
