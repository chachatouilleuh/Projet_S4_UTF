using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountUpdate : MonoBehaviour
{
    [SerializeField, Tooltip("recup le layer qui déclenche")]
    private LayerMask m_layer;

    [SerializeField, Tooltip("le gameobject est un record")]
    private bool m_isRecord;

    [SerializeField, Tooltip("le gameobject est une sonde")]
    private bool m_isProbe;


    private void OnTriggerEnter(Collider other)
    {
        if ((m_layer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (m_isProbe)
            {
                var m_probeCount = PlayerPrefs.GetInt("probeCount");
                PlayerPrefs.SetInt("probeCount", m_probeCount++);
            }
            else if (m_isRecord)
            {
                var m_recordCount = PlayerPrefs.GetInt("recordCount");
                PlayerPrefs.SetInt("probeCount", m_recordCount++);
            }
        }
    }
}
