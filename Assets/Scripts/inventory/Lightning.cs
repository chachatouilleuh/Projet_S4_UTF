using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour, ILightning
{
    [SerializeField, Tooltip("trigger l'event de la platorm")]
    private Event m_triggeredEvent;
    
    [SerializeField, Tooltip("clé pour activer")]
    private List<KeyType> m_key = new List<KeyType>();
    
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
    }
}
