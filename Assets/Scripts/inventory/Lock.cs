using System;
using System.Collections.Generic;
using UnityEngine;
public class Lock : MonoBehaviour, ILock
    {
        [SerializeField, Tooltip("trigger de l'event")]
        private Event m_triggeredEvent;
        
        [SerializeField, Tooltip("type de clés")]
        private List<KeyType> m_keyNeed = new List<KeyType>();

        private void OnEnable()
        {
            m_triggeredEvent.onTriggered += HandleTriggerEvent;
        }

        private void OnDisable()
        {
            m_triggeredEvent.onTriggered -= HandleTriggerEvent;
        }

        private void HandleTriggerEvent(List<KeyType> PlayerKeyTypes)
        {
            OpenLock(PlayerKeyTypes);
        }

        public void OpenLock(List<KeyType> p_playerKeys)
        {
            foreach (var key in m_keyNeed)
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
            // ouvre la porte
            transform.position += new Vector3(0, 4, 0);
        }
    }
