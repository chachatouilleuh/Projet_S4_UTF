using UnityEngine;
public class Probes : MonoBehaviour, IProbes
    {
        [SerializeField, Tooltip("Recup les données de la sonde")]
        private KeyType m_probes;

        public bool GetProbes(out KeyType o_probes)
        {
            bool probesFound = false;
            //loot de la probes
            if (m_probes == null)
            {
                Debug.Log("Pas de sonde");
            }
            else
            {
                probesFound = true;
                Debug.Log($"Tu as récupéré {m_probes}");
            }
            o_probes = m_probes;
            return probesFound;
        }
    }
