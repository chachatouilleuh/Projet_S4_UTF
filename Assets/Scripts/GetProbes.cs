using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetProbes : MonoBehaviour
{
    [SerializeField, Tooltip("le layer des sondes")]
    private LayerMask m_layerProbes;

    private void OnTriggerEnter(Collider other)
    {
        if ((m_layerProbes.value & (1 << other.gameObject.layer)) > 0)
        {
            Probes myProbes = other.GetComponent<Probes>();
        }
    }
}
