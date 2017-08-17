using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PoliticoCard : Card {

    public Transform propriedades;
    public TextMesh textMesh_Custo;
    public TextMesh textMesh_Rouba;

    public int custo;
    public int rouba;
    
 
    public void Start()
    {
        Setup();
    }
    public override void Setup()
    {
        base.Setup();
        textMesh_Custo.text = "R$"+custo.ToString();
        textMesh_Rouba.text = "R$"+rouba.ToString();
        propriedades.gameObject.active = false;
    }
    
    public override void DrawCard()
    {
        base.DrawCard();
        propriedades.gameObject.active = true;
    }

    public void Steal()
    {
        transform.DOJump(BoardManager.m_instance.bufunfa.position, 1, 1 , 0.2f, false ).OnComplete(TakeMoney);
        //transform.DOMove(BoardManager.m_instance.bufunfa.position, 0.2f, false).SetEase(Ease.InOutQuad).OnComplete(TakeMoney);
    }
    public void TakeMoney()
    {
        Shake();
        BoardManager.m_instance.Doar(rouba);
    }
    
}
