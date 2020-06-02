using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Models
{
    public class Deck
    {
        public Dictionary<string, string> CardImages = new Dictionary<string, string>();
        


        public Card[] Cards { get; set; }

        public Deck()
        {
            Cards = new Card[52];
            var index = 0;

            foreach (var suit in new[] { "Spades", "Hearts", "Clubs", "Diamonds", })
            {
                for (var rank = 1; rank <= 10; rank++)
                {
                    Cards[index++] = new Card(rank, suit, Convert.ToString(rank));
                }
                
            }
            Cards[40] = new Card(10, "Diamonds", "Jack");
            Cards[41] = new Card(10, "Diamonds", "Queen");
            Cards[42] = new Card(10, "Diamonds", "King");
            Cards[43] = new Card(10, "Spades", "Jack");
            Cards[44] = new Card(10, "Spades", "Queen");
            Cards[45] = new Card(10, "Spades", "King");
            Cards[46] = new Card(10, "Hearts", "Jack");
            Cards[47] = new Card(10, "Hearts", "Queen");
            Cards[48] = new Card(10, "Hearts", "King");
            Cards[49] = new Card(10, "Clubs", "Jack");
            Cards[50] = new Card(10, "Clubs", "Queen");
            Cards[51] = new Card(10, "Clubs", "King");

            CardImages.Add((Cards[0].Suit + Cards[0].Name), "AS");

            CardImages.Add((Cards[1].Suit + Cards[1].Name), "2S");
            CardImages.Add((Cards[2].Suit + Cards[2].Name), "3S");
            CardImages.Add((Cards[3].Suit + Cards[3].Name), "4S");
            CardImages.Add((Cards[4].Suit + Cards[4].Name), "5S");
            CardImages.Add((Cards[5].Suit + Cards[5].Name), "6S");
            CardImages.Add((Cards[6].Suit + Cards[6].Name), "7S");
            CardImages.Add((Cards[7].Suit + Cards[7].Name), "8S");
            CardImages.Add((Cards[8].Suit + Cards[8].Name), "9S");
            CardImages.Add((Cards[9].Suit + Cards[9].Name), "10S");

            CardImages.Add(Cards[10].Suit + Cards[10].Name, "AH");
            CardImages.Add(Cards[11].Suit + Cards[11].Name, "2H");
            CardImages.Add(Cards[12].Suit + Cards[12].Name, "3H");
            CardImages.Add(Cards[13].Suit + Cards[13].Name, "4H");
            CardImages.Add(Cards[14].Suit + Cards[14].Name, "5H");
            CardImages.Add(Cards[15].Suit + Cards[15].Name, "6H");
            CardImages.Add(Cards[16].Suit + Cards[16].Name, "7H");
            CardImages.Add(Cards[17].Suit + Cards[17].Name, "8H");
            CardImages.Add(Cards[18].Suit + Cards[18].Name, "9H");
            CardImages.Add(Cards[19].Suit + Cards[19].Name, "10H");


            CardImages.Add(Cards[20].Suit + Cards[20].Name, "AC");
            CardImages.Add(Cards[21].Suit + Cards[21].Name, "2C");
            CardImages.Add(Cards[22].Suit + Cards[22].Name, "3C");
            CardImages.Add(Cards[23].Suit + Cards[23].Name, "4C");
            CardImages.Add(Cards[24].Suit + Cards[24].Name, "5C");
            CardImages.Add(Cards[25].Suit + Cards[25].Name, "6C");
            CardImages.Add(Cards[26].Suit + Cards[26].Name, "7C");
            CardImages.Add(Cards[27].Suit + Cards[27].Name, "8C");
            CardImages.Add(Cards[28].Suit + Cards[28].Name, "9C");
            CardImages.Add(Cards[29].Suit + Cards[29].Name, "10C");
                       
            CardImages.Add(Cards[30].Suit + Cards[30].Name, "AD");
            CardImages.Add(Cards[31].Suit + Cards[31].Name, "2D");
            CardImages.Add(Cards[32].Suit + Cards[32].Name, "3D");
            CardImages.Add(Cards[33].Suit + Cards[33].Name, "4D");
            CardImages.Add(Cards[34].Suit + Cards[34].Name, "5D");
            CardImages.Add(Cards[35].Suit + Cards[35].Name, "6D");
            CardImages.Add(Cards[36].Suit + Cards[36].Name, "7D");
            CardImages.Add(Cards[37].Suit + Cards[37].Name, "8D");
            CardImages.Add(Cards[38].Suit + Cards[38].Name, "9D");
            CardImages.Add(Cards[39].Suit + Cards[39].Name, "10D");


            CardImages.Add(Cards[40].Suit + Cards[40].Name, "JD");
            CardImages.Add(Cards[41].Suit + Cards[41].Name, "QD");
            CardImages.Add(Cards[42].Suit + Cards[42].Name, "KD");

            CardImages.Add(Cards[43].Suit + Cards[43].Name, "JS");
            CardImages.Add(Cards[44].Suit + Cards[44].Name, "QS");
            CardImages.Add(Cards[45].Suit + Cards[45].Name, "KS");

            CardImages.Add(Cards[46].Suit + Cards[46].Name, "JH");
            CardImages.Add(Cards[47].Suit + Cards[47].Name, "QH");
            CardImages.Add(Cards[48].Suit + Cards[48].Name, "KH");
            
            CardImages.Add(Cards[49].Suit + Cards[49].Name, "JC");
            CardImages.Add(Cards[50].Suit + Cards[50].Name, "QC");
            CardImages.Add(Cards[51].Suit + Cards[51].Name, "KC");
            


        }

        public static void Shuffle<T>(T[] items)
        {
            Random rand = new Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

    }
}