using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeInOut : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("canvas est un dialogue")] private bool m_isDialogue;
    
    [SerializeField, Tooltip("le canvas noir de transition")] private MaskableGraphic m_blackCanvas ;
    [SerializeField, Tooltip("le temps de fade")]private float m_fadeTime;
    [SerializeField, Tooltip("le temps d'attente")]private float m_waitBeforePlay;
    
    
    [SerializeField, Tooltip("fade est déjà joué")]private bool m_alreadyFaded;

    
    [SerializeField, Tooltip("le canvas des sous-titres")] private GameObject m_subtitleCanvas ;
    [SerializeField, Tooltip("le texte des sous-titres")] TMP_Text m_textToDisplay;
    
    [SerializeField, Tooltip("le temps d'apparition des sous-titres")]private float m_subtitleTime;
    [SerializeField, Tooltip("pause à chaque point")]private float dotPause;
    [SerializeField, Tooltip("pause à chaque virgule")]private float commaPause;
    [SerializeField, Tooltip("pause à chaque espace")]private float spacePause;
    [SerializeField, Tooltip("pause entre caractères")]private float normalPause;
    
    [SerializeField, Tooltip("le canvas est déjà affiché")] private bool m_alreadyPlayed;
   
    
    
    private void Start()
    {
        m_subtitleCanvas.SetActive(false);
        m_blackCanvas.CrossFadeAlpha(0, m_fadeTime, false);
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
                    StartCoroutine(TypeSentence(m_textToDisplay.text));
                    StartCoroutine(HideSubtitles());
                }  
            }
            else
            {
                FadeIn();
            }
            m_alreadyPlayed = true;
        }
        
    }
    IEnumerator HideSubtitles()
    {
        yield return new WaitForSeconds(m_subtitleTime);
        m_subtitleCanvas.SetActive(false);
    }
    
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(m_waitBeforePlay);
        m_blackCanvas.CrossFadeAlpha(0, m_fadeTime, false);
        m_alreadyFaded = true;
    }
    
    void FadeIn()
    {
        m_fadeTime += Time.deltaTime;
        m_blackCanvas.CrossFadeAlpha(1, 0.5f, false);
    }

    IEnumerator TypeSentence (string sentence){
        m_textToDisplay.text ="";
        foreach (char letter in sentence.ToCharArray()){
            m_textToDisplay.text += letter;
            yield return StartCoroutine(PauseBetweenChars(letter));
        }
    }

    private IEnumerator PauseBetweenChars(char letter)
    {
        switch (letter)
        {
            case '.':
                yield return new WaitForSeconds(dotPause);
                break;
            case ',':
                yield return new WaitForSeconds(commaPause);
                break;
            case ' ':
                yield return new WaitForSeconds(spacePause);
                break;
            default:
                yield return new WaitForSeconds(normalPause);
                break;
        }
    }
}
