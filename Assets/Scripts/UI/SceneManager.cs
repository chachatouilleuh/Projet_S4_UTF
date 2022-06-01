using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

[System.Serializable]
public class SceneManager : MonoBehaviour
{
    // SCENE TRANSITION

    [SerializeField, Tooltip("le background de chargement")] private GameObject m_backgroundLoad;
    [SerializeField, Tooltip("la barre de chargement")] private Slider m_progressBar;
    [SerializeField, Tooltip("la barre de chargement")] private List<AsyncOperation> l_scenesLoading = new List<AsyncOperation>();
    private float m_totalSceneProgress;


    public void OpenMenuScene()
    {
        m_backgroundLoad.SetActive(true);
        l_scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName: "Playtest"));
        l_scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName: "Menu", UnityEngine.SceneManagement.LoadSceneMode.Additive));
        FirstPersonLook.m_isOption = false;

        StartCoroutine(GetLoadingProgress());
    }

    public void OpenGameScene()
    {
        m_backgroundLoad.SetActive(true);
        l_scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName: "Menu"));
        l_scenesLoading.Add(UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName: "Playtest", UnityEngine.SceneManagement.LoadSceneMode.Additive));
        FirstPersonLook.m_isOption = false;

        StartCoroutine(GetLoadingProgress());
    }

    public void QuitApplication()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }

    public IEnumerator GetLoadingProgress()
    {
        for(int i=0; i<l_scenesLoading.Count; i++)
        {
            while (l_scenesLoading[i].isDone)
            {
                m_totalSceneProgress = 0;
                
                foreach(AsyncOperation operation in l_scenesLoading)
                {
                    m_totalSceneProgress += operation.progress;
                }

                m_totalSceneProgress = (m_totalSceneProgress / l_scenesLoading.Count) * 100f;

                m_progressBar.value = Mathf.RoundToInt(m_totalSceneProgress);
                
                yield return null;
            }
        }
        m_backgroundLoad.SetActive(false);
        
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName: "Menu");
        //UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName: "Playtest");
    }
    
    public void LoadingUpdater(float value )
    {
        foreach(AsyncOperation operation in l_scenesLoading)
        {
            m_totalSceneProgress += operation.progress;
            value = m_totalSceneProgress;
            //m_progressBar.value = Mathf.RoundToInt(value);
        }
        m_progressBar.value = Mathf.RoundToInt(value);
        //m_totalSceneProgress = value;
    }
    
    
}