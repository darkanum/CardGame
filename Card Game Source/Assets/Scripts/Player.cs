using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour{

    public Transform cardsContainer;
    public Deck deck;
    public Pile graveyeard;
    public Transform handSlotsTransform;
    [SerializeField]
    public List<Slot> hand;
    public Transform boardSlotsTransform;
    [SerializeField]
    public List<Slot> cardsOnBoard;
    public Board m_board;

    private void Awake()
    {
        if(cardsContainer != null)
        {
            Card[] cards = cardsContainer.GetComponentsInChildren<Card>();
            List<Card> cl = new List<Card>();
            foreach (Card c in cards)
            {
                c.m_player = this;
                cl.Add(c);
            }
            deck.AddCards(cl);
        }

        hand = new List<Slot>();
        foreach(Transform t in handSlotsTransform)
        {
            Slot s = new Slot();
            s.Position = t;
            hand.Add(s);
        }

        m_board = boardSlotsTransform.GetComponent<Board>();
        cardsOnBoard = new List<Slot>();
        foreach(Transform t in boardSlotsTransform)
        {
            Slot s = new Slot();
            s.Position = t;
            cardsOnBoard.Add(s);
        }
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(DrawFirstHand());
    }

    IEnumerator DrawFirstHand()
    {
        List<Card> firstHand = deck.BuyFirstHand();
        foreach (Card c in firstHand)
        {
            c.DrawCard(GetSlot());
            yield return new WaitForSeconds(0.5f);  
        }
    }
	

    public void StartStealing()
    {
        StartCoroutine(Steal());
    }

    IEnumerator Steal()
    {
        foreach (Slot s in cardsOnBoard)
        {
            if (s.isOccupied)
            {
                if(s.m_card.GetType() == typeof(PoliticoCard))
                {
                    PoliticoCard card = s.m_card as PoliticoCard;
                    card.Steal();
                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }
    public Slot GetBoardSlot() {
        foreach (Slot s in cardsOnBoard)
        {
            if (!s.isOccupied)
            {
                return s;
            }
        }
        return null;
    }
    public Slot GetSlot()
    {
        foreach (Slot s in hand)
        {
            if (!s.isOccupied)
            {
                return s;
            }
        }
        return null;
    }
    void BuyCard()
    {
        foreach (Slot s in hand)
        {
            if (!s.isOccupied)
            {
                //return s.Position;
            }
        }
    }
}

[System.Serializable]
public class Slot
{
    public Transform Position;
    public bool isOccupied;
    public Card m_card;
}

