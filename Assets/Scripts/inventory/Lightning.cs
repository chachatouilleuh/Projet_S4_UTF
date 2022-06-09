using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour, ILightning
{
    [SerializeField, Tooltip("trigger l'event de la platorm")]
    private Event m_triggeredEvent;
    
    [SerializeField, Tooltip("clé pour activer")]
    private List<KeyType> m_key = new List<KeyType>();

    [SerializeField] private Material m_lampOff;
    [SerializeField] private Material m_lampOn;
    [SerializeField] private List<GameObject> l_spotLights;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = m_lampOff;
        foreach (var spotties in l_spotLights)
        {
            spotties.SetActive(false);
        }
    }

    private void OnEnable()
    {
        m_triggeredEvent.onTriggered += HandleTriggerEvent;
    }
    
    private void OnDisable()
    {
        m_triggeredEvent.onTriggered -= HandleTriggerEvent;
    }

    private void HandleTriggerEvent(List<KeyType> p_playekey)
    {
        ActiveLight(p_playekey);
    }

    public void ActiveLight(List<KeyType> p_playerKeys)
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
        Debug.Log("Active la lumière + émissive");
        gameObject.GetComponent<MeshRenderer>().material = m_lampOn;
        foreach (var spotties in l_spotLights)
        {
            spotties.SetActive(true);
        }
    }
}
