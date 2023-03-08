using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    // The Card class represents a single playing card, with a rank and a suit.
public class Card
{
    // Private fields to store the rank and suit of the card.
    private string rank;
    private string suit;

    // Constructor to initialize the rank and suit of the card.
    public Card(string rank, string suit)
    {
        this.rank = rank;
        this.suit = suit;
    }

    // ToString() method to return a string representation of the card.
    public override string ToString()
    {
        return rank + " of " + suit;
    }
}

}
