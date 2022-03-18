using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetProbes : MonoBehaviour
{
    [SerializeField, Tooltip("le layer des sondes")] private LayerMask m_layerProbes;
    [SerializeField, Tooltip("la caméra du perso")] Camera fpsCam;
    [SerializeField, Tooltip("la range pour pick l'objet")] private float m_distance;

    [SerializeField, Tooltip("inventaire")]
    private List<ProbesType> m_inventaire = new List<ProbesType>();

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
                    if (myProbes != null && myProbes.GetProbes(out ProbesType o_probes))
                    {
                        if (!m_inventaire.Contains(o_probes))
                        {
                            m_inventaire.Add(o_probes);
                            Destroy(hit.transform.gameObject);
                        }
                    }
                }
            }
        }
    }
}
