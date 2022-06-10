using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ReactRecord : MonoBehaviour
{
    [SerializeField, Tooltip("le texte de react record")] private GameObject m_textReact;

    private void Awake()
    {
        throw new NotImplementedException();
    }

    public void LaunchReactSub()
    {
        StartCoroutine(ShowThenHide());
    }

    IEnumerator ShowThenHide()
    {
        m_textReact.SetActive(true);
        StartCoroutine(TypeSentence(m_textReact.GetComponent<TextMeshProUGUI>().text));
        Debug.Log("yes");
        yield return new WaitForSeconds(10);
        m_textReact.SetActive(false);
        Debug.Log("oh yes");
    }
    
    IEnumerator TypeSentence (string sentence){
        m_textReact.GetComponent<TextMeshProUGUI>().text ="";
        foreach (char letter in sentence.ToCharArray()){
            m_textReact.GetComponent<TextMeshProUGUI>().text += letter;
            yield return StartCoroutine(PauseBetweenChars(letter));
        }
    }

    private IEnumerator PauseBetweenChars(char letter)
    {
        switch (letter)
        {
            case '.':
                yield return new WaitForSeconds(0.3f);
                break;
            case ',':
                yield return new WaitForSeconds(0.2f);
                break;
            case ' ':
                yield return new WaitForSeconds(0.1f);
                break;
            default:
                yield return new WaitForSeconds(0.04f);
                break;
        }
    }
}
