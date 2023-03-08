using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Pack object.
            Pack pack = new Pack();

            // Shuffle the pack using the Fisher-Yates shuffle algorithm.
            bool shuffleSuccess = Pack.shuffleCardPack(1);
            if (shuffleSuccess)
            {
                Console.WriteLine("The pack has been successfully shuffled.");
            }
            else
            {
                Console.WriteLine("Shuffling the pack failed.");
            }

            // Deal a single card from the pack and print it.
            Card card1 = Pack.dealCard();
            if (card1 != null)
            {
                Console.WriteLine("Dealt card: " + card1.ToString());
            }
            else
            {
                Console.WriteLine("Dealing a card failed.");
            }

            // Deal five cards from the pack and print them.
            List<Card> cards = Pack.dealCard(5);
            if (cards != null)
            {
                Console.WriteLine("Dealt cards:");
                foreach (Card card in cards)
                {
                    Console.WriteLine(card.ToString());
                }
            }
            else
            {
                Console.WriteLine("Dealing cards failed.");
            }
       
          }

        }
    }
}
