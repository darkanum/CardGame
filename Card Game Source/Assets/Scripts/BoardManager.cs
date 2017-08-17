﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoardManager : MonoBehaviour {

    public static BoardManager m_instance = null;

    public Transform deck;
    public Transform graveyard;
    public Transform bufunfa;
    public Transform cueca;

    [SerializeField]
    private List<Slot> player1_hand;
    [SerializeField]
    private List<Slot> player2_hand;
    [SerializeField]
    private List<AnimatedProp> bufunfas;
    [SerializeField]
    private List<AnimatedProp> cuecaList;
    int cuecaIndex = 0;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }  else if(m_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Setup();
    }

    private void Setup()
    {
        bufunfas = new List<AnimatedProp>();
        AnimatedProp[] t_list = bufunfa.GetComponentsInChildren<AnimatedProp>();
        
        foreach(AnimatedProp t in t_list)
        {
            bufunfas.Add(t);
        }

        cuecaList = new List<AnimatedProp>();
        t_list = cueca.GetComponentsInChildren<AnimatedProp>();

        foreach(AnimatedProp t in t_list)
        {
            cuecaList.Add(t);
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform GetHandPosition()
    {
        foreach(Slot s in player1_hand)
        {
            if (!s.isOccupied)
            {
                return s.Position;
            }
        }
        return graveyard;
    }

    public void Doar(float valor)
    {
        AnimatedProp t = bufunfas[bufunfas.Count - 1];
        t.FadeOut();
        BubunfaRemoveLast();
     }

    public void BubunfaRemoveLast() {

        bufunfas.RemoveAt(bufunfas.Count - 1);
        cuecaList[cuecaIndex].FadeIn();
        cuecaIndex++;
        AudioManager.m_instance.PlayAudio(AudioManager.AudioFX.money);
    }
}

[System.Serializable]
public class Slot
{
    public Transform Position;
    public bool isOccupied;
    Card m_card;
}