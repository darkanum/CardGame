using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : Pile {

	public void ShuffleDeck()
    {
        cards.Sort();
        ShuffleDeck();
    }
    public List<Card> BuyFirstHand()
    {
        List<Card> c = cards.GetRange(cards.Count - 6, 5);
        cards.RemoveRange(cards.Count - 6, 5);
        return c;
    }

    public Card BuyCard()
    {
        Card c = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return c;
    }
}
