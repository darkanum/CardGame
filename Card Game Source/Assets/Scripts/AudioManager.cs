using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour {

    public static AudioManager m_instance;
    private AudioSource m_audioSource;

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

        m_audioSource = GetComponent<AudioSource>();
    }

    public enum AudioFX
    {
        money
    }

    [SerializeField]
    public AudioFX m_audioFX;

    [SerializeField]
    private List<AudioClip> m_audioList;

    public void PlayAudio(AudioFX fx)
    {
        Debug.Log("audio");
        m_audioSource.clip = m_audioList[(int)fx];
        m_audioSource.Play();
    }
}
