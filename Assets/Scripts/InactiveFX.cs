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
    
    private void Start()
    {
        if(!m_activeFX)
        {
            StartCoroutine(DelayStop());
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
            m_listFX[i].GetComponent<ParticleSystem>().Stop();
                    
        }
    }
    IEnumerator DelayStop()
    {
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < m_listFX.Count; i++)
        {
            m_listFX[i].GetComponent<ParticleSystem>().Stop();
        }
    }
}
