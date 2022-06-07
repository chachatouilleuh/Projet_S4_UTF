using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class platforms : MonoBehaviour, Iplatforms
{
    [SerializeField, Tooltip("trigger l'event de la platorm")]
    private Event m_triggeredEvent;
    
    [SerializeField, Tooltip("clé pour activer")]
    private List<KeyType> m_key = new List<KeyType>();

    [SerializeField, Tooltip("anim de la platform")]
    private Animator m_animator;

    private Coroutine m_platformMoveCor;

    [SerializeField, Tooltip("temps avant que la platforme monte/descende")]
    private float m_secondsWait;

    [SerializeField, Tooltip("temps avant cut son")] private float m_waitCut;

    [SerializeField, Tooltip("la plateforme bouge x fois ?")]
    private bool m_moveALot;
    
    private string m_openTriggerName = "InActive";
    private string m_closeTriggerName = "Active";
    private int m_openHash;
    private int m_closeHash;

    [SerializeField] private bool m_isSingle; 

    [SerializeField, Tooltip("le sfx a jouer")] private AudioMixerGroup m_audioMixer;
    [SerializeField, Tooltip("le sfx a jouer")] private AudioClip m_clipToPlay;

    private AudioSource m_audiosourceTrigger;

    private void Awake()
    {
        if (m_animator == null)
        {
            m_animator = GetComponent<Animator>();
            if (m_animator == null)
            {
                throw new System.ArgumentNullException();
            }
        }

        m_openHash = Animator.StringToHash(m_openTriggerName);
        m_closeHash = Animator.StringToHash(m_closeTriggerName);

        m_audiosourceTrigger = gameObject.GetComponent<AudioSource>();
        m_audiosourceTrigger.outputAudioMixerGroup = m_audioMixer;
        m_audiosourceTrigger.clip = m_clipToPlay;
    }

    private void OnEnable()
    {
        m_triggeredEvent.onTriggered += HandleTriggerEvent;
    }
    
    private void OnDisable()
    {
        m_triggeredEvent.onTriggered -= HandleTriggerEvent;
        if (m_platformMoveCor != null)
        {
            StopCoroutine(m_platformMoveCor);
            m_platformMoveCor = null;
        }
    }

    private void HandleTriggerEvent(List<KeyType> PlayerKeyTypes)
    {
        MovePlatforms(PlayerKeyTypes);
    }

    public void MovePlatforms(List<KeyType> p_playerKeys)
    {
        foreach (var key in m_key)
        {
            if (p_playerKeys.Contains(key))
            {
                Debug.Log($"tu a la clé {key.name}");
            }
            else
            {
                Debug.Log($"il te manque la clé {key.name}");
                return;
            }
        }

        if (!m_moveALot)
        {
            m_animator?.SetTrigger(m_closeHash);
            m_audiosourceTrigger.Play();
            if(m_isSingle)
            {
                //StartCoroutine(StopSound());
            }
        }
        else
        {
            LaunchMove();
            InvokeRepeating("LaunchMove", 0f, m_secondsWait + 4);
            m_audiosourceTrigger.Play();
        }
    }

    private void LaunchMove()
    {
        m_platformMoveCor = StartCoroutine(AnimationPlatform());
    }

    IEnumerator AnimationPlatform()
    {
        m_animator?.SetTrigger(m_openHash);
        
        yield return new WaitForSeconds(m_secondsWait);
        
        m_animator?.SetTrigger(m_openHash);
    }

    // IEnumerator StopSound()
    // {
    //     yield return new WaitForSeconds(m_waitCut);
    //     m_audiosourceTrigger.Stop();
    // }
}
