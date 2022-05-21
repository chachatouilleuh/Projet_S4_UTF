using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchShifter : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("l'audio mixer de musique a mettre")] private AudioMixerGroup m_audioMixer;

    [SerializeField, Tooltip("la vitesse de shift � atteindre de 0 à 2")]  private float m_newSpeed;
    private float m_normalSpeed, m_currentSpeed;
    private bool m_isTriggered;

    // Update is called once per frame
    private void Start()
    {
        MasterPitch();
    }

    private void Update()
    {
        switch (m_isTriggered)
        {
           case true:
               if (m_newSpeed < m_normalSpeed && m_currentSpeed > m_newSpeed)
               {
                   StartCoroutine(DecreaseToNew());
               }
               else if( m_newSpeed > m_normalSpeed && m_currentSpeed < m_newSpeed)
               {
                   StartCoroutine(IncreaseToNew());
               }
               else if (m_currentSpeed == m_newSpeed)
               {
                   StopAllCoroutines();
               }
               break;
           
           case false:
               if (m_newSpeed < m_normalSpeed && m_currentSpeed < m_normalSpeed )
               {
                   StartCoroutine(IncreaseToNormal());
               }
               else if(m_newSpeed > m_normalSpeed && m_currentSpeed > m_normalSpeed)
               {
                   StartCoroutine(DecreaseToNormal());
               }
               else if (m_currentSpeed == m_normalSpeed)
               {
                   StopAllCoroutines();
               }
               break;
        }
    }

    private void MasterPitch()
    {
        float value;
        bool result = m_audioMixer.audioMixer.GetFloat("pitchShifter", out value);
        if (result)
        {
            m_normalSpeed =  value;
            m_currentSpeed = m_normalSpeed;
            Debug.Log(m_normalSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            m_isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            m_isTriggered = false;
        }
    }
    
    IEnumerator IncreaseToNew()
    {
        m_currentSpeed += 0.0005f; 
        m_audioMixer.audioMixer.SetFloat("pitchShifter", m_currentSpeed);
        yield return new WaitForSeconds(0.1f);
    }
    
    IEnumerator IncreaseToNormal()
    {
        m_currentSpeed += 0.001f; 
        m_audioMixer.audioMixer.SetFloat("pitchShifter", m_currentSpeed);
        yield return new WaitForSeconds(0.1f);
    }
    
    IEnumerator DecreaseToNew()
    {
        m_currentSpeed -= 0.0005f; 
        m_audioMixer.audioMixer.SetFloat("pitchShifter", m_currentSpeed);
        yield return new WaitForSeconds(0.01f);
    }
    
    IEnumerator DecreaseToNormal()
    {
        m_currentSpeed -= 0.001f; 
        m_audioMixer.audioMixer.SetFloat("pitchShifter", m_currentSpeed);
        yield return new WaitForSeconds(0.01f);
    }

}

