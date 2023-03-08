using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223
{


// The Pack class represents a pack of playing cards, with 52 cards in total.
    public class Pack
    {
        // Private field to store an array of Card objects.
        private Card[] cards;

        // Constructor to initialize the array with 52 cards.
        public Pack()
        {
            // Define an array of ranks and suits.
            string[] ranks = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
            string[] suits = {"Hearts", "Diamonds", "Clubs", "Spades"};

            // Initialize the cards array with 52 cards.
            cards = new Card[52];
            int index = 0;
            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards[index] = new Card(rank, suit);
                    index++;
                }
            }
        }

        // Shuffle the pack of cards using the Fisher-Yates shuffle algorithm.
        public static bool shuffleCardPack(int typeOfShuffle)
        {
            // Check the type of shuffle requested.
            if (typeOfShuffle == 1)
            {
                // Fisher-Yates shuffle algorithm.
                Random rand = new Random();
                int n = cards.Length;
                for (int i = n - 1; i > 0; i--)
                {
                    int j = rand.Next(i + 1);
                    Card temp = cards[j];
                    cards[j] = cards[i];
                    cards[i] = temp;
                }
                return true;
            }
            else if (typeOfShuffle == 2)
            {
                // Riffle shuffle algorithm.
                // TODO: Implement riffle shuffle.
                return false;
            }
            else if (typeOfShuffle == 3)
            {
                // No shuffle.
                return true;
            }
            else
            {
                // Invalid shuffle type.
                return false;
            }
        }

        // Deal a single card from the pack.
        public static Card dealCard()
        {
            // Check if there are any cards left in the pack.
            if (cards.Length > 0)
            {
                // Remove the top card from the pack and return it.
                Card card = cards[0];
                List<Card> temp = new List<Card>(cards);
                temp.RemoveAt(0);
                cards = temp.ToArray();
                return card;
            }
            else
            {
                // No cards left in the pack.
                return null;
            }
        }

        // Deal a specified number of cards from the pack.
        public static List<Card> dealCard(int amount)
        {
            // Check if there are enough cards left in the pack.
            if (cards.Length >= amount)
            {
                // Remove the top cards from the pack and return them as a list.
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                dealtCards.Add(cards[i]);
            }
            List<Card> temp = new List<Card>(cards);
            temp.RemoveRange(0, amount);
            cards = temp.ToArray();
            return dealtCards;
        }
        else
        {
            // Not enough cards left in the pack.
            return null;
        }
    }


}
