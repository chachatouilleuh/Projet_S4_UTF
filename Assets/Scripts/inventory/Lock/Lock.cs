using System.Collections.Generic;
using inventory.Object;
using UnityEngine;

namespace inventory.Lock
{
    public class Lock : MonoBehaviour, ILock
    {
        [SerializeField, Tooltip("type de clés")]
        private KeyType m_keyNeed;

        public void OpenLock(List<KeyType> p_playerKeys)
        {
            if (m_keyNeed)
            {
                if (p_playerKeys == null || !p_playerKeys.Contains(m_keyNeed))
                {
                    Debug.Log($" {m_keyNeed.name} est nécessaire");
                    return;
                }
            }
        
            Debug.Log($" {m_keyNeed.name} est activé");
        }
    }
}
