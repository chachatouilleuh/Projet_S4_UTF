using System;
using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DialogueManager : MonoBehaviour
{
    private int i;
    private string actualText = "";
    private string sentence = "";
    
    public TextMeshProUGUI logTextBox;

    [SerializeField, Tooltip("check A")]private float dotPause;
    [SerializeField, Tooltip("check A")]private float commaPause;
    [SerializeField, Tooltip("check A")]private float spacePause;
    [SerializeField, Tooltip("check A")]private float normalPause;

    public void ReproduceText()
    {
        //if not read all letters
        if(i < logTextBox.text.Length)
        {
            //get one letter
            char letter = logTextBox.text[i];
            //sentence = logTextBox.text;
            
            //Actualize on screen
            //logTextBox.text += Unwrite(sentence);
            
            logTextBox.text.Replace(logTextBox.text, actualText);
            logTextBox.text += Write(letter);
            
            
            i++;
            StartCoroutine(PauseBetweenChars(letter));
            
        }
    }

    // private void Update()
    // {
    //     Debug.Log(logTextBox.text.Length);
    //     logTextBox.text = actualText;
    // }

    private string Write(char letter)
    {
        logTextBox.text = "";
        actualText += letter;
        return actualText;
    }
    // private string Unwrite(string sentence)
    // {
    //     actualText -= sentence;
    //     return actualText;
    // }

    private IEnumerator PauseBetweenChars(char letter)
    {
        //Debug.Log(letter);
        
        switch (letter)
        {
            case '.':
                yield return new WaitForSeconds(dotPause);
                Debug.Log("je fonctionne comme une pute");
                ReproduceText();
                break;
            case ',':
                yield return new WaitForSeconds(commaPause);
                Debug.Log("je fonctionne comme une pute2");
                ReproduceText();
                break;
            case ' ':
                yield return new WaitForSeconds(spacePause);
                Debug.Log("je fonctionne comme une pute3");
                ReproduceText();
                break;
            default:
                yield return new WaitForSeconds(normalPause);
                Debug.Log("je fonctionne comme une pute4");
                ReproduceText();
                break;
        }
    }
}
