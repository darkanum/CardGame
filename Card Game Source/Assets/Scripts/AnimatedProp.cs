using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimatedProp : MonoBehaviour {

    public SpriteRenderer m_spriteRenderer;

	void Awake () {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
    public void FadeOut()
    {
        m_spriteRenderer.DOFade(0, 0.3f);
    }

    public void FadeIn()
    {
        m_spriteRenderer.DOFade(1, 0.3f);
    }
}
