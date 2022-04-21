using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEvent : MonoBehaviour
{
    [SerializeField, Tooltip("appel du trigger")]
    private Event m_triggeredEvent;

    [SerializeField, Tooltip("recup le gameobject")]
    private Rigidbody m_boxTriggered;

    private Coroutine m_boxEventCor;

    [SerializeField, Tooltip("temps avant de detruire objet")]
    private float m_SecondsWait;

    [SerializeField, Tooltip("destroy object ?")]
    private bool m_objetDestroy;

    private void OnEnable()
    {
        m_triggeredEvent.onTrigger += HandleTriggerEvent;
    }

    private void OnDisable()
    {
        m_triggeredEvent.onTrigger -= HandleTriggerEvent;
        
        if (m_boxEventCor != null)
        {
            StopCoroutine(m_boxEventCor);
            m_boxEventCor = null;
        }
    }

    private void HandleTriggerEvent()
    {
        m_boxTriggered.GetComponent<Rigidbody>().isKinematic = false;

        if (m_objetDestroy)
        {
            m_boxEventCor = StartCoroutine(Boxdestroy());
        }
    }

    IEnumerator Boxdestroy()
    {
        yield return new WaitForSeconds(m_SecondsWait);
        
        Destroy(gameObject);
    }
}