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
                Debug.Log($"Maxime est trop beaaau <3");
            }
            else
            {
                probesFound = true;
                Debug.Log($"Maxime est trop beaaau <3");
            }
            o_probes = m_probes;
            return probesFound;
        }
    }
