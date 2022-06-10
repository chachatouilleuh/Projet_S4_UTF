using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SnapObjects : MonoBehaviour
{

    [SerializeField, Tooltip("Get transform of the empty object")]
    private Transform m_snapPoint;

    [SerializeField, Tooltip("layer de l'objet a poser")]
    private LayerMask m_layerBox;
    
    [SerializeField, Tooltip("trigger de l'event")]
    private Event m_triggeredEvent;

    [SerializeField, Tooltip("recup l'inventaire du player")]
    private Inventory m_Inventory;

    [SerializeField, Tooltip("je peux poser une box ?")]
    private bool m_activate;
    
    
    [SerializeField, Tooltip("animation de la plaque")]
    private Animator m_animator;

    private string m_openTriggerName = "Activate";
    private int m_openHash;

    [SerializeField, Tooltip("le vfx a jouer")]
    private ParticleSystem Electricity;
    
    //Son
    [SerializeField, Tooltip("le sfx a jouer")] private AudioMixerGroup m_audioMixer;
    [SerializeField, Tooltip("le sfx a jouer")] private AudioClip m_clipToPlay;

    private AudioSource m_audiosourceTrigger;

    private void Awake()
    {
        if (m_animator == null)
        {
            m_animator = GetComponent<Animator>();
            if (m_animator == null)
            {
                throw new System.ArgumentNullException();
            }
        }
        m_openHash = Animator.StringToHash(m_openTriggerName);
        
        m_audiosourceTrigger = gameObject.GetComponent<AudioSource>();
        m_audiosourceTrigger.outputAudioMixerGroup = m_audioMixer;
        m_audiosourceTrigger.clip = m_clipToPlay;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if ((m_layerBox.value & (1 << other.gameObject.layer)) > 0)
        {
            if (!m_activate)
            {
                //cube
                other.transform.position = m_snapPoint.position;
                other.transform.rotation = m_snapPoint.rotation;
                other.gameObject.layer = 0;
                other.GetComponent<Rigidbody>().isKinematic = true;
                
                //active la plate
                m_activate = true;
                
                //active anim
                m_animator?.SetTrigger(m_openHash);

                //vfx
                Electricity.Play();
                
                //sfx
                m_audiosourceTrigger.Play();
            }

            Plate myPlates = GetComponent<Plate>();
            if (myPlates != null && myPlates.ActivePlate(out KeyType o_plates))
            {
                if (!m_Inventory.m_inventaire.Contains(o_plates))
                {
                    m_Inventory.m_inventaire.Add(o_plates);
                    m_triggeredEvent.Raise(m_Inventory.m_inventaire);
                }
            }
        }
    }
}
