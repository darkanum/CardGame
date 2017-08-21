using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Card : MonoBehaviour {

    protected enum State
    {
        onDeck,
        onHand,
        onBoard,
        onGraveyard
    }

    [SerializeField]
    protected State m_state;

    protected enum CardType
    {
        politico,
        trapaca
    }

    [SerializeField]
    protected CardType m_cardType;
    
    private SpriteRenderer m_spriteRenderer;
    public SpriteRenderer m_artSpriteRenderer;
    public Sprite m_cardBack;
    public Sprite m_sprite;
    public Sprite m_art;
    public Transform m_position;
    public Player m_player;
    public string description;

    public virtual void Setup()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = m_cardBack;
        m_state = State.onDeck;
        transform.DOMove(BoardManager.m_instance.deck.position, 0.5f, false).SetEase(Ease.InOutQuad);
    }

    public virtual void DrawCard( Slot slot)
    {
        m_state = State.onHand;
        m_spriteRenderer.sprite = m_sprite;
        m_artSpriteRenderer.sprite = m_art;
        m_position = slot.Position;
        slot.isOccupied = true;
        slot.m_card = this;
        transform.DOMove(m_position.position, 0.5f, false).SetEase(Ease.InOutQuad);

    }

    public virtual void PlayCard() {
        m_state = State.onBoard;
    }

    public virtual void Discard()
    {
        m_state = State.onGraveyard;
        transform.DOShakePosition(0.5f, 0.1f, 10, 90, false, true).OnComplete(MoveToGraveyard);

    }
    public void MoveToGraveyard()
    {
        transform.DOMove(BoardManager.m_instance.graveyard.position, 0.5f, false).SetEase(Ease.InOutQuad);
    }
    public void Shake()
    {
            transform.DOShakePosition(0.5f, new Vector3(0.1f,0.1f), 10, 90, false, true).OnComplete(ReturnToposition);
    }

    public void ReturnToposition()
    {
        transform.DOMove(m_position.position, 0.5f, false).SetEase(Ease.InOutQuad);
    }

    public void OnMouseEnter()
    {
        if (m_state == State.onBoard || m_state == State.onHand && !isDragging)
        {
            transform.DOScale(0.6f, 0.15f);
            Description.m_instance.Show(description);
        }
    }


    public bool isDragging;
    public void OnMouseDrag()
    {
        if (m_state == State.onHand)
        {
            isDragging = true;
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPosition;
            Description.m_instance.Hide();
            transform.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public virtual void OnMouseUp()
    {
        if (isDragging)
        {
            transform.DOMove(m_position.position, 0.25f, false).SetEase(Ease.InOutQuad).OnComplete(SetDraggingFalse);

        }
    }
    
    private void SetDraggingFalse()
    {
        isDragging = false;
        transform.GetComponent<BoxCollider2D>().enabled = true ;
    }
    public void OnMouseExit()
    {
        if (m_state == State.onBoard || m_state == State.onHand)
        {
            Description.m_instance.Hide();
            transform.DOScale(0.5f, 0.15f);
        }
    }
}
