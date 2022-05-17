using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DialogueManager : MonoBehaviour
{
    //private int index;
    private string actualText = "";
    
    public TextMeshProUGUI logTextBox;

    [SerializeField, Tooltip("check A")]private float dotPause;
    [SerializeField, Tooltip("check A")]private float commaPause;
    [SerializeField, Tooltip("check A")]private float spacePause;
    [SerializeField, Tooltip("check A")]private float normalPause;

    public void ReproduceText()
    {
        //if not read all letters
        for(int i = 0; i < logTextBox.text.Length; i++)
        {

            //get one letter
            char letter = logTextBox.text[i];
            
            
            //Actualize on screen
            logTextBox.text = Write(letter);

            //set to go to the 
            i += 1;
            StartCoroutine(PauseBetweenChars(letter));
        }
    }

    private string Write(char letter)
    {
        actualText += letter;
        return actualText;
    }

    private IEnumerator PauseBetweenChars(char letter)
    {
        
        switch (letter)
        {
            case '.':
                yield return new WaitForSeconds(dotPause);
                Debug.Log("je fonctionne comme une pute");
                break;
            case ',':
                yield return new WaitForSeconds(commaPause);
                Debug.Log("je fonctionne comme une pute2");
                break;
            case ' ':
                yield return new WaitForSeconds(spacePause);
                Debug.Log("je fonctionne comme une pute3");
                break;
            default:
                yield return new WaitForSeconds(normalPause);
                Debug.Log("je fonctionne comme une pute4");
                break;
        }
    }
}
