using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    [SerializeField, Tooltip("la langue selectionee")] private int m_language;
    IEnumerator Start() {
        yield return LocalizationSettings.InitializationOperation;
    }

    private void Update()
    {
        m_language = Underlining.m_lang;
        
        if (m_language >= 0 || m_language <= 1)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[m_language]; 
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}