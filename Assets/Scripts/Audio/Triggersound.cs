using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    private AudioSource m_audiosourceTrigger;
    
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("le sfx open hud a jouer")] private AudioClip m_clipToPlay;
    
    [SerializeField, Tooltip("le son est deja joue")] private bool alreadyPlayed;
    
    
    
    private void Start()
    {
        m_audiosourceTrigger = gameObject.GetComponent<AudioSource>();
        //m_audiosourceTrigger.outputAudioMixerGroup = Sound.audioMixer;
        alreadyPlayed = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0 && !alreadyPlayed)
        {
            m_audiosourceTrigger.PlayOneShot(m_clipToPlay);
            alreadyPlayed = true;
        }
    }
}
