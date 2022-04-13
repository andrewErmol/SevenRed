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
        private Point lastPoint;

        
        private List<TextBox> WhiteSlot;
        private List<TextBox> BlackSlot;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClouseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Movement of window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        /// <summary>
        /// Find point of movement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Add Cards to TextBoxes and check of correct data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCards_Click(object sender, EventArgs e)
        {
            List<string> whiteDeck = WhiteDeckText.Lines.ToList();
            List<string> blackDeck = BlackDeckText.Lines.ToList();

            try
            {
                if (whiteDeck.Count <= 8 && blackDeck.Count <= 8)
                {
                    CardsCombination.ConvertListStringToListCard(whiteDeck: whiteDeck, blackDeck: blackDeck);
                    
                    WhiteSlot = new List<TextBox>(7) { whiteCard1, whiteCard2, whiteCard3, whiteCard4, whiteCard5, whiteCard6, whiteCard7 };
                    BlackSlot = new List<TextBox>(7) { blackCard1, blackCard2, blackCard3, blackCard4, blackCard5, blackCard6, blackCard7 };

                    ResetTextbox(WhiteSlot);
                    ResetTextbox(BlackSlot);

                    EnterCardsToWinForms(CardsCombination.WhiteDeck, WhiteSlot);
                    EnterCardsToWinForms(CardsCombination.BlackDeck, BlackSlot);
                }
                else
                {
                    throw new Exception("Too many cards");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        /// <summary>
        /// Cleans textboxes
        /// </summary>
        /// <param name="Slot"></param>
        private void ResetTextbox(List<TextBox> Slot)
        {
            Color standartColor = Color.FromArgb(37, 87, 50);

            for (int i = 0; i < Slot.Count; i++)
            {
                Slot[i].Text = "";
                Slot[i].BackColor = standartColor;
            }
        }

        /// <summary>
        /// Enter of textbox text and colors
        /// </summary>
        /// <param name="Deck"></param>
        /// <param name="Slot"></param>
        private void EnterCardsToWinForms(List<Card> Deck, List<TextBox> Slot)
        {
            for (int i = 0; i < Deck.Count; i++)
            {
                Slot[i].Text = Deck[i].Nominal.ToString();
                Slot[i].ForeColor = Color.White;
                Slot[i].BackColor = ColorTranslator.FromHtml(Deck[i].Color.ToString());
            }
        }

        /// <summary>
        /// Find wins combination
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindAWinner_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Service.GetResult());
        }
    }
}
