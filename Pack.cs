using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
   public class Pack
{
    private List<Card> _cards;

    public Pack()
    {
        _cards = new List<Card>();

        foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    public bool Shuffle(int typeOfShuffle)
    {
        switch (typeOfShuffle)
        {
            case 1: // Fisher-Yates Shuffle
                int n = _cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = new Random().Next(n + 1);
                    Card card = _cards[k];
                    _cards[k] = _cards[n];
                    _cards[n] = card;
                }
                break;
            case 2: // Riffle Shuffle
                // TODO: Implement riffle shuffle
                break;
            case 3: // No Shuffle
                // Do nothing
                break;
            default:
                throw new ArgumentException("Invalid shuffle type");
        }

        return true;
    }

    public Card Deal()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("Pack is empty");
        }

        Card card = _cards[0];
        _cards.RemoveAt(0);

        return card;
    }

    public List<Card> Deal(int amount)
    {
        if (_cards.Count < amount)
        {
            throw new InvalidOperationException("Not enough cards in pack");
        }

        List<Card> cards = new List<Card>();

        for (int i = 0; i < amount; i++)
        {
            cards.Add(Deal());
        }

        return cards;
    }
}

}
