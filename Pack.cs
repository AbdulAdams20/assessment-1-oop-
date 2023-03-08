using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMP1903M_A01_2223
{
    public class Pack
    {
        private List<Card> pack; // A list to store the cards in the pack

        // A constructor to initialize the card pack
        public Pack()
        {
            pack = new List<Card>();
            // Loop through each suit
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                // Loop through each rank
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    // Add a new card to the pack
                    pack.Add(new Card(suit, rank));
                }
            }
        }

        // A method to shuffle the card pack based on the type of shuffle
        public static bool ShuffleCardPack(int typeOfShuffle)
        {
            // Check if the type of shuffle is valid
            if (typeOfShuffle < 1 || typeOfShuffle > 3)
            {
                return false;
            }

            // Create a new Random object for shuffling
            Random rand = new Random();

            // Perform the shuffle based on the type of shuffle
            switch (typeOfShuffle)
            {
                case 1: // Fisher-Yates Shuffle
                    for (int i = pack.Count - 1; i > 0; i--)
                    {
                        int j = rand.Next(i + 1);
                        Card temp = pack[i];
                        pack[i] = pack[j];
                        pack[j] = temp;
                    }
                    break;
                case 2: // Riffle Shuffle
                    int half = pack.Count / 2;
                    List<Card> leftHalf = pack.Take(half).ToList();
                    List<Card> rightHalf = pack.Skip(half).ToList();
                    pack.Clear();
                    while (leftHalf.Count > 0 && rightHalf.Count > 0)
                    {
                        int shuffleType = rand.Next(1, 3);
                        int count = shuffleType == 1 ? rand.Next(1, 3) : 1;
                        count = Math.Min(count, Math.Min(leftHalf.Count, rightHalf.Count));
                        switch (shuffleType)
                        {
                            case 1: // Overhand Shuffle
                                pack.AddRange(leftHalf.Take(count));
                                leftHalf.RemoveRange(0, count);
                                break;
                            case 2: // Hindu Shuffle
                                pack.AddRange(rightHalf.Take(count));
                                rightHalf.RemoveRange(0, count);
                                break;
                        }
                    }
                    pack.AddRange(leftHalf);
                    pack.AddRange(rightHalf);
                    break;
                case 3: // No Shuffle
                    // Do nothing
                    break;
            }
            return true;
        }

        // A method to deal one card from the pack
        public static Card DealCard()
        {
            // Check if there are any cards left in the pack
            if (pack.Count == 0)
            {
                return null;
            }

            // Remove and return the top card from the pack
            Card card = pack[0];
            pack.RemoveAt(0);
            return card;
        }

        // A method to deal a specified number of cards from the pack
        public static List<Card> DealCards(int amount)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                Card card = DealCard();
                if (card != null)
                {
                    cards.Add(card);
                }
                else
                {
                    break;
                }
            }
            return cards;
        }
    }
}
