using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class EnergyCube : MonoBehaviour
{
    //Coroutine
    [SerializeField, Tooltip("temps avant de rejouer le son")] private float m_SecondsWait;
    private Coroutine m_soundCor;
    
    //son
    [SerializeField, Tooltip("layer ground")] private LayerMask m_groundLayer;
    [SerializeField, Tooltip("le sfx a jouer")] private AudioMixerGroup m_audioMixer;
    [SerializeField, Tooltip("le sfx a jouer")] private AudioClip m_clipToPlay;
    [SerializeField, Tooltip("can audio ?")] private bool m_canAudio;
    private AudioSource m_audiosourceTrigger;

    private void OnDisable()
    {
        if (m_soundCor != null)
        {
            StopCoroutine(m_soundCor);
            m_soundCor = null;
        }
    }

    private void Awake()
    {
        m_audiosourceTrigger = gameObject.GetComponent<AudioSource>();
        m_audiosourceTrigger.outputAudioMixerGroup = m_audioMixer;
        m_audiosourceTrigger.clip = m_clipToPlay;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((m_groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            if (m_canAudio)
            {
                m_soundCor = StartCoroutine(WaitForSound());
                m_canAudio = false;
            }
        }
    }

    IEnumerator WaitForSound()
    {
        m_audiosourceTrigger.Play();

        yield return new WaitForSeconds(m_SecondsWait);

        m_canAudio = true;
    }
}
