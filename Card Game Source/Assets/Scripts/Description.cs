using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Description : MonoBehaviour {
    public static Description m_instance;

    public void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    public Canvas myCanvas;

    public Text m_text;
    public RectTransform panel;


    private void Start()
    {
        Hide();
    }
    // Update is called once per frame
    void Update () {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        panel.transform.position = myCanvas.transform.TransformPoint(pos);
    }
    
    public void Show(string s)
    {
        panel.gameObject.active = true;
        m_text.text = s;
        panel.GetComponent<Image>().DOFade(1, .4f);
        m_text.DOFade(1, .8f);

    }

    public void Hide()
    {
        panel.GetComponent<Image>().DOFade(0, .4f).OnComplete(DisablePanel);
        m_text.DOFade(0, .2f);

        m_text.text = "";
    }
    void DisablePanel()
    {
        panel.gameObject.active = false;
    }
}
