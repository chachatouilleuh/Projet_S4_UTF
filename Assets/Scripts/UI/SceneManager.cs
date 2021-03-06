using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;

[System.Serializable]
public class SceneManager : MonoBehaviour
{
    // SCENE TRANSITION
    
    public void OpenMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Menu");
        FirstPersonLook.m_isOption = false;
    }

    public void OpenCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Credits");
    }
    
    public void OpenGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Alpha");
        FirstPersonLook.m_isOption = false;
    }

    public void QuitApplication()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }
    //__________________________________________________________________//
    
    // RESET 
    
    // public void ResetSave()
    // {
    //     PlayerPrefs.DeleteKey("level");
    // }
    
    //__________________________________________________________________//
    
    //PAUSE
    
    // public void PauseGame ()
    // {
    //     Time.timeScale = 0;
    //     AudioListener.pause = true;
    // }
    //
    // public void ResumeGame ()
    // {
    //     Time.timeScale = 1;
    //     AudioListener.pause = false;
    // }

    
    
    //__________________________________________________________________//
    
    // CHECKPOINT
    
    // Lecture du checkpoint
    // public int checkpoint;
    
    // private void Start()
    // {
    //     chercher le premier checkpoint au lancement du jeu 
    //     checkpoint = PlayerPrefs.GetInt("level", 1);
    // }
    
    // Passer au checkpoint suivant
    // public void LevelUp(){
    //
    //     if (checkpoint == 1){
    //         PlayerPrefs.SetInt("level", 2);
    //     }
    //
    //     else if (checkpoint == 2){
    //         PlayerPrefs.SetInt("level", 3);
    //     }
    //
    //     else if (checkpoint == 3){
    //         PlayerPrefs.SetInt("level", 4);
    //     }   
    //
    //     else if (checkpoint == 4){
    //         PlayerPrefs.SetInt("level", 5);
    //     }  
    // }
    
}