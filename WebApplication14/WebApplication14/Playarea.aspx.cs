using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication14.Models;

namespace WebApplication14
{
    public partial class Playarea : System.Web.UI.Page
    {
        public Deck deck = new Deck();
        public Player dealer = new Player(0);
        public Player player = new Player(0);
        public Random rnd = new Random();
        readonly int StartingAmount = 500;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnDeal.Enabled = true;
            btnHit.Enabled = false;
            btnPass.Enabled = false;
            btnRestart.Enabled = false;
            lblPMoney.Enabled = false;

        }

        protected void DealCards(object sender, EventArgs e)
        {

            //getting playermoney from session
            if (lblPMoney.Text == null || lblPMoney.Text == "")
            {
                StartGame();
            }
            if (Session["money"] != null)
            {
                lblPMoney.Text = Session["money"].ToString();
            }


            //START GAME
            //shuffle
            Deck.Shuffle<Card>(deck.Cards);

            //give cards
            player.Hand.Add(Deal(rnd.Next(1, 52)));
            player.Hand.Add(Deal(rnd.Next(1, 52)));
            dealer.Hand.Add(Deal(rnd.Next(1, 52)));
            dealer.Hand.Add(Deal(rnd.Next(1, 52)));

            //disable bet box
            txtBet.Enabled = false;
            txtPlayerScore.Text = Convert.ToString(UpdateScore(player));
            txtDealerScore.Text = Convert.ToString(UpdateScore(dealer));
            int pmoney = Convert.ToInt32(lblPMoney.Text);
            
            //save session
            Session["player"] = player;
            Session["dealer"] = dealer;

            //Make Images;
            List<Card> playerHandImages = player.Hand;
            List<Card> dealerListImages = dealer.Hand;
            MakeImages(playerHandImages, dealerListImages);

            int pscore = Convert.ToInt32(txtPlayerScore.Text);
            if (pscore == 21)
            {
                ShowMessage("Black Jack, you win.");
                int Pot = Convert.ToInt32(txtBet.Text);
                int playerMoney = Convert.ToInt32(lblPMoney.Text) + Pot;
                lblPMoney.Text = playerMoney.ToString();
                GameOver(pmoney);
                return;
            }
            int dscore = Convert.ToInt32(txtDealerScore.Text);
            if (dscore == 21)
            {
                ShowMessage("Black Jack, dealer wins.");
                int Pot = Convert.ToInt32(txtBet.Text);
                int playerMoney = Convert.ToInt32(lblPMoney.Text) - Pot;
                lblPMoney.Text = playerMoney.ToString();
                GameOver(pmoney);
                return;
            }


            btnDeal.Enabled = false;
            btnHit.Enabled = true;
            btnPass.Enabled = true;

        }

        protected void Hit(object sender, EventArgs e)
        {
            //load session
            Player player = (Player)Session["player"];
            txtPlayerScore.Text = Convert.ToString(player.Score);
            Player dealer = (Player)Session["dealer"];
            txtDealerScore.Text = Convert.ToString(dealer.Score);

            //give player a card
            player.Hand.Add(Deal(rnd.Next(1, 52)));
            txtPlayerScore.Text = Convert.ToString(UpdateScore(player));

            //give dealer a card
            int dscore = Convert.ToInt32(txtDealerScore.Text);
            if (dscore < 17)
            {
                dealer.Hand.Add(Deal(rnd.Next(1, 52)));
                txtDealerScore.Text = Convert.ToString(UpdateScore(dealer));


            }
            //MakeImages();
            List<Card> playerHandImages = player.Hand;
            List<Card> dealerHandImages = dealer.Hand;

            MakeImages(playerHandImages, dealerHandImages);

            //check if win or lose

            int p = (UpdateScore(player));
            int d = (UpdateScore(dealer));
            int pmoney = Convert.ToInt32(lblPMoney.Text);


            btnDeal.Enabled = false;
            btnHit.Enabled = true;
            btnPass.Enabled = true;
            CheckScore(p, d, pmoney);


            //save session
            Session["player"] = player;
            Session["dealer"] = dealer;
        }

        protected void Pass(object sender, EventArgs e)
        {
            //load session
            Player player = (Player)Session["player"];
            txtPlayerScore.Text = (player.Score).ToString();
            Player dealer = (Player)Session["dealer"];
            txtDealerScore.Text = (dealer.Score).ToString();

            //give dealer a card
            int dscore = Convert.ToInt32(txtDealerScore.Text);
            if (dscore < 17)
            {
                dealer.Hand.Add(Deal(rnd.Next(1, 52)));
                txtDealerScore.Text = Convert.ToString(UpdateScore(dealer));


            }

            //MakeImages();
            List<Card> playerHandImages = player.Hand;
            List<Card> dealerHandImages = dealer.Hand;
            
            MakeImages(playerHandImages, dealerHandImages);

            //check if win or lose
            int p = (UpdateScore(player));
            int d = (UpdateScore(dealer));
            int pmoney = Convert.ToInt32(lblPMoney.Text);


            btnDeal.Enabled = false;
            btnHit.Enabled = true;
            btnPass.Enabled = true;
            CheckScore(p, d, pmoney);


            //save session
            Session["player"] = player;
            Session["dealer"] = dealer;




            int m = player.Money;
            if (IsBankrupt(m))
            {
                GameOver(pmoney);
            }
        }


        protected void DealerCard()
        {
            dealer.Hand.Add(Deal(rnd.Next(1, 52)));
        }

        protected void Restart(object sender, EventArgs e)
        {
            txtDealerScore.Text = "";
            txtPlayerScore.Text = "";
            lblMsg.Text = "";
            btnDeal.Enabled = true;
            btnHit.Enabled = false;
            btnPass.Enabled = false;
            btnRestart.Enabled = false;
            txtBet.Enabled = true;
        }

        protected void GameOver(int pmoney)
        {
            btnDeal.Enabled = false;
            btnHit.Enabled = false;
            btnPass.Enabled = false;
            btnRestart.Enabled = true;
            txtBet.Enabled = true;
            lblPMoney.Text = pmoney.ToString();
        }

        public void ShowMessage(string msg)
        {
            lblMsg.Text = msg;
        }

        protected int UpdateScore(Player p)
        {
            int score = 0;
            foreach(Card c in p.Hand)
            {
                score += c.Rank;
            }
            if(p == player)
            {
                player.Score = score;
            } else
            {
                dealer.Score = score;
            }
            return score;
        }

        protected Card Deal(int rnd)
        {
                Card currentCard = deck.Cards[rnd];
                return currentCard;
        }


        protected void MakeImages(List<Card> cdlist, List<Card> dealerlist)
        {
            double punctX = 10;
            double spacing = 5;

            Panel1.Style["position"] = "relative";
            Deck testDeck = new Deck();

            foreach(Card cd in cdlist)
            {
                string path = testDeck.CardImages[cd.Suit + cd.Name];

                Image image = new Image
                {
                    Width = 60,
                    Height = 100,
                    ImageUrl = "~/PNG/" + path + ".png"
                };

                Panel1.Controls.Add(image);

                punctX += image.Width.Value + spacing;
            }

            foreach (Card cd in dealerlist)
            {
                string path = testDeck.CardImages[cd.Suit + cd.Name];

                Image image = new Image
                {
                    Width = 60,
                    Height = 100,
                    ImageUrl = "~/PNG/" + path + ".png"
                };

                Panel2.Controls.Add(image);

                punctX += image.Width.Value + spacing;
            }


        }


        public void CheckScore(int pscore, int dscore, int pmoney)
        {


            if (pscore > 21)
            {
                ShowMessage("You lose.");
                RoundEnd();
                int Pot = Convert.ToInt32(txtBet.Text);
                int playerMoney = pmoney;
                int net = playerMoney - Pot;
                lblPMoney.Text = net.ToString();
                txtBet.Enabled = false;
            }
            if (dscore > 21)
            {
                ShowMessage("Dealer bust, you win.");
                RoundEnd();
                int Pot = Convert.ToInt32(txtBet.Text);
                int playerMoney = pmoney;
                int net = playerMoney + Pot;
                lblPMoney.Text = net.ToString();
                txtBet.Enabled = false;
            }
            if (pscore == 21)
            {
                ShowMessage("You win.");
                RoundEnd();
                int Pot = Convert.ToInt32(txtBet.Text);
                int playerMoney = pmoney;
                int net = playerMoney + Pot;
                lblPMoney.Text = net.ToString();
                txtBet.Enabled = false;
            }
            if (dscore == 21)
            {
                ShowMessage("You lose.");
                RoundEnd();
                int Pot = Convert.ToInt32(txtBet.Text);
                int playerMoney = pmoney;
                int net = playerMoney - Pot;
                lblPMoney.Text = net.ToString();
                txtBet.Enabled = false;

            }
        }



        public void RoundEnd()
        {
            btnDeal.Enabled = false;
            btnHit.Enabled = false;
            btnPass.Enabled = false;
            btnRestart.Enabled = true;
        }


        public bool IsBankrupt(int money)
        {
            if(money < 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void StartGame()
        {
            lblPMoney.Text = StartingAmount.ToString(); ;

        }


    }
}