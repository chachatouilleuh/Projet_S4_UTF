using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField, Tooltip("le canvas des sous-titres")] private GameObject m_subtitleCanvas ;
    [SerializeField, Tooltip("le canvas noir de transition")] private MaskableGraphic m_blackCanvas ;

    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    
    [SerializeField, Tooltip("canvas est un dialogue")] private bool m_isDialogue;
    [SerializeField, Tooltip("le canvas est déjà affiché")] private bool m_alreadyPlayed;
    
    [SerializeField, Tooltip("fade est déjà joué")]private bool m_alreadyFaded;
    [SerializeField, Tooltip("le temps de fade")]private float m_fadeTime;
    [SerializeField, Tooltip("le temps de fade")]private float m_subtitleTime;
    
    
    private void Start()
    {
        m_subtitleCanvas.SetActive(false);
        m_blackCanvas.CrossFadeAlpha(0, 1f, false);
    }
    
    void Update()
    {
        if(m_alreadyPlayed)
        {
            StartCoroutine(FadeOut());
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0 && !m_alreadyPlayed)
        {
            if (m_isDialogue)
            {
                if (Underlining.m_sub == 0)
                {
                    m_subtitleCanvas.SetActive(true);
                    StartCoroutine(HideSubtitles());
                }  
            }
            else
            {
                fadeIn();
            }
        }
        m_alreadyPlayed = true;
    }
    IEnumerator HideSubtitles()
    {
        yield return new WaitForSeconds(m_subtitleTime);
        m_subtitleCanvas.SetActive(false);
    }
    
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(m_fadeTime);
        m_blackCanvas.CrossFadeAlpha(0, 2.5f, false);
        m_alreadyFaded = true;
    }
    
    void fadeIn()
    {
        m_fadeTime += Time.deltaTime;
        m_blackCanvas.CrossFadeAlpha(1, 0.5f, false);
    }
}
