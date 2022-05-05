using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour, ITriggerZone
{
    [SerializeField, Tooltip("trigger de l'event")]
    private Event m_triggeredEvent;

    [SerializeField, Tooltip("recup le layer qui déclenche")]
    private LayerMask m_layer;

    [SerializeField, Tooltip("la clé la")] 
    private KeyType m_key;

    private void OnTriggerEnter(Collider other)
    {
        if ((m_layer.value & (1 << other.gameObject.layer)) > 0)
        {
            m_triggeredEvent.Chouck();
        }
    }

    public bool ActiveTriggerZone(out KeyType o_triggerZone)
    {
        bool keyCheck = false;

        if (m_key == null)
        {
            Debug.Log("pas la clé ");
        }
        else
        {
            keyCheck = true;
            Debug.Log("tu as la clé demandé");
        }

        o_triggerZone = m_key;
        return keyCheck;
    }
}
