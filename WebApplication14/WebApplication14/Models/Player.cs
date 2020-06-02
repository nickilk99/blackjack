using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Player
    {
        public int Score { set; get; }

        public List<Card> Hand { set; get; }

        public int Money { get; set; }

        public Player(int score, List<Card> hand)
        {
            this.Score = score;
            this.Hand = hand;
        }

        public Player(int score)
        {
            this.Score = score;
            this.Hand = new List<Card>();
        }
        public Player(int score, int money)
        {
            this.Score = score;
            this.Money = money;
        }


        public override string ToString()
        {
            return "Score: " + Score + " hand: " + Hand[0].Name;
        }
    }
}