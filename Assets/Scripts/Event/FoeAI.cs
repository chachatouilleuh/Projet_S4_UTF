using System;
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
    
    //animation
    [SerializeField, Tooltip("animator")] 
    private Animator m_animator;

    private string m_activeBoolName = "Crawl";
    private int m_activeHash;
    
    

    private void OnEnable()
    {
        m_agentAI = GetComponent<NavMeshAgent>();
        m_triggeredEvent.onTrigger += HandleTriggerEvent;
    }

    private void OnDisable()
    {
        m_triggeredEvent.onTrigger -= HandleTriggerEvent;
    }

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

        m_activeHash = Animator.StringToHash(m_activeBoolName);
    }

    private void HandleTriggerEvent()
    {
        m_agentAI.SetDestination(m_waypointList[m_indexWaypoint].position);
        m_animator?.SetTrigger(m_activeHash);
    }
}
