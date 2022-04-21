using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioSource audiosource;
    
    [SerializeField, Tooltip("le son est deja joue")] private bool alreadyPlayed;
    
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    
    private void Start()
    {
        audiosource.Stop();
        alreadyPlayed = false;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0 && !alreadyPlayed)
        {
            audiosource.Play();
            alreadyPlayed = true;
        }
    }
}
