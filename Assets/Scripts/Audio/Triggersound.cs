using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class TriggerSound : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("le sfx a jouer")] private AudioMixerGroup m_audioMixer;
    [SerializeField, Tooltip("le sfx a jouer")] private AudioClip m_clipToPlay;
    [SerializeField, Tooltip("le son est une musique")] private bool m_isMusic;
    [SerializeField, Tooltip("le son est deja joue")] private bool alreadyPlayed;
    [SerializeField, Tooltip("le temps d'attente avant de play")]private float m_waitBeforePlay;
    
    private AudioSource m_audiosourceTrigger;

    private void Start()
    {
        m_audiosourceTrigger = gameObject.AddComponent<AudioSource>();
        m_audiosourceTrigger.outputAudioMixerGroup = m_audioMixer;
        m_audiosourceTrigger.clip = m_clipToPlay;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            yield return new WaitForSeconds(m_waitBeforePlay);
            if (m_isMusic)
            {
                m_audiosourceTrigger.loop = true;
                m_audiosourceTrigger.Play();
            }
            else
            {
                if(!alreadyPlayed)
                m_audiosourceTrigger.Play();
                alreadyPlayed = true;  
            }
        }
    }
}
