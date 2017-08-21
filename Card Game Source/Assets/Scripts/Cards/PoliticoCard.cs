using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PoliticoCard : Card {

    public Transform propriedades;

    public TextMeshPro textMesh_Custo;
    public TextMeshPro textMesh_Rouba;
    //public TextMesh textMesh_Custo;
    //public TextMesh textMesh_Rouba;

    public int custo;
    public int rouba;
    
    private bool isOnBoardArea = false;
    public void Start()
    {
        Setup();
    }
    public override void Setup()
    {
        base.Setup();
        textMesh_Custo.text = "R$"+custo.ToString();
        textMesh_Rouba.text = "R$"+rouba.ToString();
        propriedades.gameObject.SetActive(false);
    }
    
    public override void DrawCard(Slot slot)
    {
        base.DrawCard(slot);
        propriedades.gameObject.active = true;
    }
    public override void PlayCard()
    {
        base.PlayCard();
        Slot s = m_player.GetBoardSlot();
        m_position = s.Position;
        s.isOccupied = true;
        s.m_card = this;
        transform.DOMove(m_position.position, 0.5f, false);
    }
    public void Steal()
    {
        Debug.Log("steal");
        transform.DOJump(BoardManager.m_instance.bufunfa.position, 1, 1 , 0.2f, false ).OnComplete(TakeMoney);
        //transform.DOMove(BoardManager.m_instance.bufunfa.position, 0.2f, false).SetEase(Ease.InOutQuad).OnComplete(TakeMoney);
    }
    public void TakeMoney()
    {
        Shake();
        BoardManager.m_instance.Doar(rouba);
    }

    public override void OnMouseUp()
    {
        if (m_player.m_board.GetIsOver()) {
            PlayCard();
        }
        base.OnMouseUp();
    }
}
