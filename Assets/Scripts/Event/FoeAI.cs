using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FoeAI : MonoBehaviour
{
    [SerializeField, Tooltip("list des points de passage")]
    private List<Transform> m_waypointList;

    [SerializeField, Tooltip("nav mesh agent")]
    private NavMeshAgent m_agentAI;

    [SerializeField, Tooltip("index du waypoint actif")]
    private int m_indexWaypoint;
    
    [SerializeField, Tooltip("appel du trigger")]
    private Event m_triggeredEvent;

    private void OnEnable()
    {
        m_agentAI = GetComponent<NavMeshAgent>();
        m_triggeredEvent.onTrigger += HandleTriggerEvent;
    }

    private void OnDisable()
    {
        m_triggeredEvent.onTrigger -= HandleTriggerEvent;
    }

    private void HandleTriggerEvent()
    {
        m_agentAI.SetDestination(m_waypointList[m_indexWaypoint].position);
    }
}
