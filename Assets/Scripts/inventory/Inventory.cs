using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
        [SerializeField, Tooltip("le layer des sondes")] 
        private LayerMask m_layerProbes;

        [SerializeField, Tooltip("le layer du trigger")]
        private LayerMask m_layerTrigger;
        
        [SerializeField, Tooltip("le layer des objet 'serrure'")] 
        private LayerMask m_layerLock;
        
        [SerializeField, Tooltip("la caméra du perso")] 
        Camera fpsCam;
        
        [SerializeField, Tooltip("la range pour pick l'objet")] 
        private float m_distance;

        [SerializeField, Tooltip("inventaire")]
        public List<KeyType> m_inventaire = new List<KeyType>();

        private void Update()
        {
            Ray pickupRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward * m_distance);
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(pickupRay, out hit, m_distance, m_layerProbes))
                {
                    if((m_layerProbes.value & (1 << hit.transform.gameObject.layer)) > 0)
                    {
                        Probes myProbes = hit.transform.gameObject.GetComponent<Probes>();
                        if (myProbes != null && myProbes.GetProbes(out KeyType o_probes))
                        {
                            if (!m_inventaire.Contains(o_probes))
                            {
                                m_inventaire.Add(o_probes);
                                Destroy(hit.transform.gameObject);
                            }
                        }
                    }
                }
            
                else if(Physics.Raycast(pickupRay, out hit, m_distance, m_layerLock))
                {
                    if ((m_layerLock.value & (1 << hit.transform.gameObject.layer)) > 0)
                    {
                        Lock myLock = hit.transform.gameObject.GetComponent<Lock>();
                        if (myLock)
                        {
                            myLock.OpenLock(m_inventaire);
                        }
                    }
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if ((m_layerTrigger.value & (1 << other.gameObject.layer)) > 0)
            {
                TriggerZone myTrigger = other.GetComponent<TriggerZone>();
                if (myTrigger)
                {
                    myTrigger.ActiveTriggerZone(m_inventaire);
                }
            }
        }
}
