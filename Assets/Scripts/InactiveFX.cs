using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactiveFX : MonoBehaviour
{
    [SerializeField, Tooltip("liste fx")] 
    private List<ParticleSystem> m_listFX;

    [SerializeField, Tooltip("active au lancement")]
    private bool m_activeFX;
    
    private void Awake()
    {
        for (int i = 0; i < m_listFX.Count; i++)
        {
            Debug.Log("5");
            m_listFX[i].GetComponent<ParticleSystem>().Stop();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < m_listFX.Count; i++)
        {
            m_listFX[i].GetComponent<ParticleSystem>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < m_listFX.Count; i++)
        {
            Debug.Log("5");
            m_listFX[i].GetComponent<ParticleSystem>().Stop();
                    
        }
    }
}
