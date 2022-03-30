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

    private void OnEnable()
    {
        m_triggeredEvent.onTriggered += HandleTriggerEvent;
    }

    private void OnDisable()
    {
        m_triggeredEvent.onTriggered -= HandleTriggerEvent;
    }

    private void HandleTriggerEvent()
    {
        m_boxTriggered.GetComponent<Rigidbody>().useGravity = true;
    }
}
