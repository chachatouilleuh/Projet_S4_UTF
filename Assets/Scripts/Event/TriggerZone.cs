using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField, Tooltip("trigger de l'event")]
    private Event m_triggeredEvent;

    [SerializeField, Tooltip("recup le layer qui déclenche")]
    private LayerMask m_layer;

    private void OnTriggerEnter(Collider other)
    {
        if ((m_layer.value & (1 << other.gameObject.layer)) > 0)
        {
            m_triggeredEvent.Raise();
        }
    }
}
