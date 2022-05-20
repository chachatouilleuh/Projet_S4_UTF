using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchShifter : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("l'audio mixer de musique a mettre")] private AudioMixerGroup m_audioMixer;

    [SerializeField, Tooltip("la vitesse de shift à atteindre")]  private float m_newSpeed;
    private float m_normalSpeed;


    // Update is called once per frame
    private void Start()
    {
        MasterPitch();
    }

    private void MasterPitch()
    {
        float value;
        bool result = m_audioMixer.audioMixer.GetFloat("pitchShifter", out value);
        if (result)
        {
            m_normalSpeed =  value;
            Debug.Log(m_normalSpeed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("je suis entré dans la zone");
            if (m_newSpeed < 0)
            {
                Debug.Log("newspeed est inférieur à 0");
                //for (float i = m_normalSpeed; i > m_newSpeed; i -= 0.00001f)
                //{
                //    m_audioMixer.audioMixer.SetFloat("pitchShifter", i);
                //    Debug.Log("Je diminue le son jusqu'à ma valeur désirée");
                //}
            }
            else if( m_newSpeed > 0)
            {
                //for (float i = m_normalSpeed; i < m_newSpeed; i += 0.00001f)
                //{
                //    m_audioMixer.audioMixer.SetFloat("pitchShifter", i);
                //}
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (m_newSpeed < 0)
            {
                //for (float i = m_newSpeed; i < m_normalSpeed; i += 0.00001f)
                //{
                //    m_audioMixer.audioMixer.SetFloat("pitchShifter", i);
                //}
            }
            else if(m_newSpeed > 0)
            {
                //for (float i = m_newSpeed; i > m_normalSpeed; i -= 0.00001f)
                //{
                //    m_audioMixer.audioMixer.SetFloat("pitchShifter", i);
                //}
            }    
        }
    }
}
