using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile:MonoBehaviour {
    public enum type
    {
        Hand,
        Deck,
        Cemetery
    }
    [SerializeField]
    public type m_type;
    public List<Card> cards;

    public void AddCards(List<Card> cardList)
    {
        cards = cardList;
    }
}
