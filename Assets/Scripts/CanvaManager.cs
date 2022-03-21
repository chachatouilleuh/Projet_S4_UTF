using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CanvaManager : MonoBehaviour
{
    public SceneManager sceneManager;
    
    public GameObject Accueil, MainMenu, Options, LoadScreen, MenuIngame,OptionsIngame ;

    //__________________________________________________________________//
    
    // OPEN CANVAS
    
    public void AccueilActive()
    {
        Accueil.SetActive(true);
    }
    
    public void MainMenuActive()
    {
        MainMenu.SetActive(true);
    }
    
    public void OptionActive()
    {
        Options.SetActive(true);
    }
    
    public void LoadScreenActive()
    {
        LoadScreen.SetActive(true);
    }
    
    public void MenuIngameActive()
    {
        MenuIngame.SetActive(true);
    }
    public void OtionsIngameActive()
    {
        OptionsIngame.SetActive(true);
    }

    //__________________________________________________________________//
    
    // CLOSE CANVAS
    public void CloseOptions()
    {
        Options.SetActive(false);
    }

    public void CloseMainMenu()
    {
        MainMenu.SetActive(false);
    }

    public void CloseMenuIngame()
    {
        MenuIngame.SetActive(false);
    }
    public void CloseOptionsIngame()
    {
        OptionsIngame.SetActive(false);
    }

    public void CloseLoadScreen()
    {
        LoadScreen.SetActive(false);
    }
    
    //__________________________________________________________________//
    
    // ICONE MANAGER
    
    //public GameObject HideButton, ShowButton;
    //private bool HideIcons;
    
    // public void FixedUpdate(){
    //     if(HideButton != null && ShowButton != null)
    //     {
    //         if (HideIcons != true){
    //                 HideButton.SetActive(true);
    //                 ShowButton.SetActive(false); 
    //             }  
    //         }       
    // }
    
    //__________________________________________________________________//
    
    // CHECKPOINT
    
    //public int checkpoint;
    
    //private void Start()
    //{
    // Sauvegarde de valeurs entre scènes
    // Checkpoint au niveau 1 au lancement du jeu
        
    //checkpoint = PlayerPrefs.GetInt("level",1);
    //PlayerPrefs.SetInt("level", 1);
        
    //En fonction de la valeur du checkpoint, charger un canvas particulier

    //     if(Accueil != null)
    //     {
    //         if(checkpoint == 1){
    //             Accueil.SetActive(true);
    //         }
    //         else if (checkpoint == 2){
    //             Niveau_2.SetActive(true);
    //         }
    //         else if (checkpoint == 3){
    //             Niveau_3.SetActive(true);
    //         }
    //         else if (checkpoint == 4){
    //             Niveau_4.SetActive(true);
    //         }
    //     }
    //}
    
    //__________________________________________________________________//
    
    // BACK BUTTON
    
    // public void BackButton()
    // {
    //     if (checkpoint == 2)
    //     {
    //         Accueil.SetActive(true);
    //         CloseNiveau2();
    //     }
    //     else if (checkpoint == 3)
    //     {
    //         Accueil.SetActive(true);
    //         CloseNiveau3();
    //     }
    //     else if (checkpoint == 4)
    //     {
    //         Accueil.SetActive(true);
    //         CloseNiveau4();
    //     }
    // }
}