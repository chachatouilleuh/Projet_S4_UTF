using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField, Tooltip("le texte a assigner")] private TMP_Text m_dialogueText;

    public float speed = 0.1f;
    
    private Queue<string> sentences;
    
    void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
         
    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence (string sentence){
        m_dialogueText.text ="";
        foreach (char letter in sentence){
            m_dialogueText.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }
}
