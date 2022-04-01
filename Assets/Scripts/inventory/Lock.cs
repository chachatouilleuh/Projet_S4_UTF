using System.Collections.Generic;
using UnityEngine;
public class Lock : MonoBehaviour, ILock
    {
        [SerializeField, Tooltip("type de clés")]
        private List<KeyType> m_keyNeed = new List<KeyType>();

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
            Debug.Log("la porte s'ouvre");
        }
    }
