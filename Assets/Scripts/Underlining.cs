using UnityEngine;
using TMPro;

public class Underlining : MonoBehaviour
{

    [SerializeField , Tooltip ("le texte a mettre")] private TMP_Text textComponent;
    [SerializeField, Tooltip("check underlined")] private bool m_isUnderlined;
    [SerializeField, Tooltip("check type")] private bool m_typeLang;
    
    public void Underlined()
    {
        if (m_isUnderlined)
        {
            //Remove Underline
            textComponent.fontStyle ^= FontStyles.Underline;
            m_isUnderlined = false;
            
            // Check type and set ON/OFF
            if (m_typeLang)
            {
                PlayerPrefs.SetInt("lang", 0);
                Debug.Log(PlayerPrefs.GetInt ("lang"));
            }
            else
            {
                PlayerPrefs.SetInt("sub", 0);
                Debug.Log(PlayerPrefs.GetInt ("sub"));
            }
            
        }
        else
        {
            //Add Underline
            textComponent.fontStyle = FontStyles.Underline;
            m_isUnderlined = true;
            //PlayerPrefs.SetInt("Language", 1);
            // Check type and set ON/OFF
            
            if (m_typeLang)
            {
                PlayerPrefs.SetInt("language", 1);
                Debug.Log(PlayerPrefs.GetInt("lang"));
            }
            else
            {
                PlayerPrefs.SetInt("sub", 1);
                Debug.Log(PlayerPrefs.GetInt("sub"));
            }
        }
    }
}
