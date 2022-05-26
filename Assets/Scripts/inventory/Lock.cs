using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Lock : MonoBehaviour, ILock
    {
        [SerializeField, Tooltip("trigger de l'event")]
        private Event m_triggeredEvent;
        
        [SerializeField, Tooltip("type de clés")]
        private List<KeyType> m_keyNeed = new List<KeyType>();

        [SerializeField, Tooltip("animation de la porte")]
        private Animator m_animator;

        private string m_openTriggerName = "Open";
        private int m_openHash;
        
        [SerializeField, Tooltip("le sfx a jouer")] private AudioMixerGroup m_audioMixer;
        [SerializeField, Tooltip("le sfx a jouer")] private AudioClip m_clipToPlay;

        private AudioSource m_audiosourceTrigger;

        private void OnEnable()
        {
            m_triggeredEvent.onTriggered += HandleTriggerEvent;
        }

        private void OnDisable()
        {
            m_triggeredEvent.onTriggered -= HandleTriggerEvent;
        }

        private void HandleTriggerEvent(List<KeyType> PlayerKeyTypes)
        {
            OpenLock(PlayerKeyTypes);
        }

        public void OpenLock(List<KeyType> p_playerKeys)
        {
            foreach (var key in m_keyNeed)
            {
                if (p_playerKeys.Contains(key))
                {
                    Debug.Log($"tu a la clé {key.name}");
                }
                else
                {
                    Debug.Log($"il te manque la clé {key.name}");
                    return;
                }
            }
            // ouvre la porte
            // transform.position += new Vector3(0, 4, 0);
            m_animator?.SetTrigger(m_openHash);
            m_audiosourceTrigger.Play();
        }

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
    }
