using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FadeOut : MonoBehaviour
{
    [SerializeField, Tooltip("audio container la")]
    private GameObject m_audioContainer;

    private AudioSource m_audioSource;

    private Coroutine m_audioCor;

    [SerializeField, Tooltip("niveau de son enlevé")]
    private float m_soundLess;

    private void OnDisable()
    {
        if (m_audioCor != null)
        {
            StopCoroutine(m_audioCor);
            m_audioCor = null;
        }
    }
    private void Awake()
    {
        m_audioSource = m_audioContainer.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        LaunchMove();
        InvokeRepeating("LaunchMove", 0.1f, 0.1f);
    }

    private void Update()
    {
        if (m_audioSource.volume == 0)
        {
            CancelInvoke("LaunchMove");
        }
    }

    private void LaunchMove()
    {
        m_audioCor = StartCoroutine(FadeOutuuu());
    }

    IEnumerator FadeOutuuu()
    {
        m_audioSource.volume -= m_soundLess;

        yield return null;
    }
}
