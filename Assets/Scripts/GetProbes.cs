using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetProbes : MonoBehaviour
{
    [SerializeField, Tooltip("le layer des sondes")]
    private LayerMask m_layerProbes;

    [SerializeField, Tooltip("inventaire")]
    private List<ProbesType> m_inventaire = new List<ProbesType>();
    private void OnTriggerEnter(Collider other)
    {
        if ((m_layerProbes.value & (1 << other.gameObject.layer)) > 0)
        {
            Probes myProbes = other.GetComponent<Probes>();
            if (myProbes != null && myProbes.GetProbes(out ProbesType probes))
            {
                if (!m_inventaire.Contains(probes))
                {
                    m_inventaire.Add(probes);
                }
            }
        }
    }
}
