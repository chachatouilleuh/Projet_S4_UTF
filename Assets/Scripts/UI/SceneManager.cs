using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class SceneManager : MonoBehaviour
{
    // SCENE TRANSITION

    [SerializeField, Tooltip("le background de chargement")] private GameObject m_backgroundLoad;
    [SerializeField, Tooltip("la barre de chargement")] private Slider m_progressBar;
    [SerializeField, Tooltip("la texte de chargement")] private TextMeshProUGUI m_progressText;
    [SerializeField, Tooltip("la texte de chargement")] private TextMeshProUGUI m_loreText;
    [SerializeField, Tooltip("l'operation de chargement")] private AsyncOperation m_loadOperation;
    //private float m_totalSceneProgress;
    private float m_progress;

    public void OpenMenuScene()
    {
        m_backgroundLoad.SetActive(true);
        FirstPersonLook.m_isOption = false;
        Cursor.visible = true;
        StartCoroutine(LoadMenuScene());
    }

    public void OpenGameScene()
    {
        m_backgroundLoad.SetActive(true);
        FirstPersonLook.m_isOption = false;
        StartCoroutine(TypeSentence(m_loreText.text));
        StartCoroutine(LoadGameScene());
    }

    private void QuitApplication()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }

    private IEnumerator LoadMenuScene()
    {
        PlayerPrefs.DeleteKey("probeCount");
        PlayerPrefs.DeleteKey("recordCount");
        m_loadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName: "Menu");
        m_loadOperation.allowSceneActivation = false;
        
        while (!m_loadOperation.isDone)
        {
            m_progress = Mathf.Clamp01(m_loadOperation.progress);
            m_progressBar.value = m_progress;
            m_progressText.text = (m_progress * 100).ToString("F0") + "%";

            if (m_loadOperation.progress >= 0.9f)
            {
                m_progressBar.value = 1;
                
                if (Underlining.m_lang == 0)
                {
                    m_progressText.text = "Press any key to continue";
                }
                else
                {
                    m_progressText.text = "Appuyez sur n'importe quelle touche pour continuer";
                }

                if (Input.anyKeyDown)
                {
                    m_loadOperation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
    
    private IEnumerator LoadGameScene()
    {
        PlayerPrefs.DeleteKey("probeCount");
        PlayerPrefs.DeleteKey("recordCount");
        m_loadOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName: "Playtest");
        m_loadOperation.allowSceneActivation = false;
        
        while (!m_loadOperation.isDone)
        {
            m_progress = Mathf.Clamp01(m_loadOperation.progress);

            m_progressBar.value = m_progress;
            m_progressText.text = (m_progress * 100).ToString("F0") + "%";
 
            if (m_loadOperation.progress >= 0.9f)
            {
                m_progressBar.value = 1;
                
                if (Underlining.m_lang == 0)
                {
                    m_progressText.text = "Press any key to continue";
                }
                else
                {
                    m_progressText.text = "Appuyez sur n'importe quelle touche pour continuer";
                }

                if (Input.anyKeyDown)
                {
                    m_loadOperation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
        
    }
    
    IEnumerator TypeSentence (string sentence)
    {
        m_loreText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            m_loreText.text += letter;
            yield return StartCoroutine(PauseBetweenChars(letter));
        }
    }
    
    private IEnumerator PauseBetweenChars(char letter)
    {
        switch (letter)
        {
            case '.':
                yield return new WaitForSeconds(0.6f);
                break;
            case ',':
                yield return new WaitForSeconds(0.2f);
                break;
            case ' ':
                yield return new WaitForSeconds(0.2f);
                break;
            default:
                yield return new WaitForSeconds(0.04f);
                break;
        }
    }
}