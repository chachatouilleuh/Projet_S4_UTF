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

    [SerializeField, Tooltip("tu as la sonde ou po ?")]
    private bool m_probeNeeded;

    private void OnTriggerStay(Collider other)
    {
        if ((m_layer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (m_probeNeeded)
            {
                m_triggeredEvent.Chouck();
                // m_probeNeeded = false;
            }
        }
    }

    public void ActiveTriggerZone(List<KeyType> p_playerProbes)
    {
        if (m_key)
        {
            if (p_playerProbes == null || !p_playerProbes.Contains(m_key))
            {
                Debug.Log($"La sonde {m_key.name} est nécessaire");
                return;
            }
        }

        m_probeNeeded = true;
    }
}
