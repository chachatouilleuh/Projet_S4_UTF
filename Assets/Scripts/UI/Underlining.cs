using UnityEngine;
using TMPro;

public class Underlining : MonoBehaviour
{
 
    // Les Textes 
    [SerializeField , Tooltip ("le texte a souligner")] private TMP_Text textA;
    [SerializeField, Tooltip("le texte avec qui switcher")] private TMP_Text textB;

    // Les Checks
    [SerializeField, Tooltip("check A")] private bool m_A;
    [SerializeField, Tooltip("check B")] private bool m_B;
    [SerializeField, Tooltip("check type")] private bool m_typeLanguage;

    // Les langues & soustitres
    public static int m_lang;
    [SerializeField, Tooltip("subtitles on/off")] private int m_sub;

    private bool m_double;

    private void Awake()
    {
            // souligne A au début
            textA.fontStyle = FontStyles.Underline;
            
            m_A = true;
            m_B = false;
        
    }

    private void Update()
    {
        m_lang = PlayerPrefs.GetInt("lang");
    }

  
    public void Underline()
    {
        CheckUnderlining();

        if (!m_double)
        {
            // Si le gameobject cliqué est A et donc pas B
            if (m_A && !m_B)
            {
                // le texte A se souligne
                textA.fontStyle ^= FontStyles.Underline;

                // le texte B se désouligne
                textB.fontStyle = FontStyles.Underline;

                m_A = false;
                m_B = true;


                // J'assigne le sous-titre ou la langue en question
                if (m_typeLanguage)
                {
                    SetLanguage();
                }
                else
                {
                    SetSubtitles();
                }
            }


            // Si le gameobject cliqué est B et donc pas A
            else if (m_B && !m_A)
            {
                // le texte A se désouligne
                textA.fontStyle = FontStyles.Underline;

                // le texte B se souligne
                textB.fontStyle ^= FontStyles.Underline;

                m_B = false;
                m_A = true;


                // J'assigne le sous-titre ou la langue en question
                if (m_typeLanguage)
                {
                    SetLanguage();
                }
                else
                {
                    SetSubtitles();
                }
            }
        }  
    }

     private void CheckUnderlining()
    {
        //si A et B sont pas soulignés
        if (!m_A && !m_B)
        {
            m_double = true;
            m_A = true;
        }

        //si A et B sont soulignés
        else if (m_A && m_B)
        {
            m_double = true;
            m_A = false;
        }     
    }

    // je change la valeur de la langue
    private void SetLanguage()
    {
        if (m_lang == 0)
        {
            PlayerPrefs.SetInt("lang", 1);
            //Debug.Log("Set Language : Je suis en fran�ais maintenant");
        }
        else
        {
            PlayerPrefs.SetInt("lang", 0);
            //Debug.Log("Set Language : Je suis en anglais maintenant");
        }
        
        m_lang = PlayerPrefs.GetInt("lang");
        //Debug.Log(m_lang);
        
    }

    // Je change la valeur des soustitres
    private void SetSubtitles()
    {
        m_sub = PlayerPrefs.GetInt("sub");

        if(m_sub == 0)
        {
            PlayerPrefs.SetInt("sub", 1);
        }

        else
        {
            PlayerPrefs.SetInt("sub", 0);
        }  
    }


}
