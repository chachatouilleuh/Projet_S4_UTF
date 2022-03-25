using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Underlining : MonoBehaviour
{

    [SerializeField , Tooltip ("le texte à mettre")] public TMP_Text textComponent;
    public bool isLangUnderlined;
    public bool isSubUnderlined;

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    switch (isLangUnderlined)
        //    {
        //        case true:
        //            //do thing A goes here...
        //            textComponent.fontStyle ^= FontStyles.Underline;
        //            isLangUnderlined = false;
        //            //PlayerPrefs.SetInt("Language", 0);
        //            break;

        //        case false:
        //            //Add Underline
        //            textComponent.fontStyle = FontStyles.Underline;
        //            isLangUnderlined = true;
        //            //PlayerPrefs.SetInt("Language", 1);

        //    }
        //}

        // Language
        if (!isLangUnderlined)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Remove Underline
                textComponent.fontStyle ^= FontStyles.Underline;
                isLangUnderlined = false;
                //PlayerPrefs.SetInt("Language", 0);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Add Underline
                textComponent.fontStyle = FontStyles.Underline;
                isLangUnderlined = true;
                //PlayerPrefs.SetInt("Language", 1);
            }
        }

        // Subtitles
        
        if (!isSubUnderlined)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Remove Underline
                textComponent.fontStyle ^= FontStyles.Underline;
                isSubUnderlined = false;
                //PlayerPrefs.SetInt("Sub", 0);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Add Underline
                textComponent.fontStyle = FontStyles.Underline;
                isSubUnderlined = true;
                //PlayerPrefs.SetInt("Sub", 1);
            }
        }  
    }
}
