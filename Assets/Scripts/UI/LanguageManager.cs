using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    IEnumerator Start() {

        // ReSharper disable once HeapView.BoxingAllocation
        yield return LocalizationSettings.InitializationOperation;
    
    // This variable selects the language. For example, if in the table your first language is English then 0 = English. If the second language in the table is Russian then 1 = Russian etc.
    int i = Underlining.m_lang;
    
    // This part changes the language
    LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }

    private void Update()
    {
        int i = Underlining.m_lang;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[i];
    }
}

