using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField, Tooltip("la plateforme bouge x fois ?")]
    private bool m_moveALot;
    
    private string m_openTriggerName = "InActive";
    private string m_closeTriggerName = "Active";
    private int m_openHash;
    private int m_closeHash;

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
            m_animator?.SetTrigger(m_openHash);
        }
        else
        {
            LaunchMove();
            InvokeRepeating("LaunchMove", 0f, m_secondsWait + 4); 
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
        
        m_animator?.SetTrigger(m_closeHash);
    }
}
