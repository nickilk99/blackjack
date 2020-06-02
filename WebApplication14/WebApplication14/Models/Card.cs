using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Card
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Suit { set; get; }

        public Card(int rank, string suit, string name)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.Name = name;
        }
    }
}