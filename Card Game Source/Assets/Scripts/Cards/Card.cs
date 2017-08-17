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

    public string description;

    public virtual void Setup()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = m_cardBack;
        m_state = State.onDeck;
        transform.DOMove(BoardManager.m_instance.deck.position, 0.5f, false).SetEase(Ease.InOutQuad);
    }

    public virtual void DrawCard()
    {
        m_state = State.onHand;
        m_spriteRenderer.sprite = m_sprite;
        m_artSpriteRenderer.sprite = m_art;
        m_position = BoardManager.m_instance.GetHandPosition();
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
        if(m_state == State.onBoard || m_state == State.onHand)
            Description.m_instance.Show(description);
    }

    public void OnMouseOver()
    {
        ShowDescription();
    }

    public void OnMouseExit()
    {
        if (m_state == State.onBoard || m_state == State.onHand)
            Description.m_instance.Hide();
    }

    public void ShowDescription()
    {

    }

    public void HideDescription()
    {

    }
}
