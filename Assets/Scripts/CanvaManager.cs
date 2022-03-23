using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CanvaManager : MonoBehaviour
{
    public SceneManager sceneManager;
    
    public GameObject Accueil, MainMenu, Options, LoadScreen, MenuIngame,OptionsIngame ;

    private bool accueilOpen = true;
    private bool mainMenuOpen, optionsOpen, loadScreenOpen, menuIngameOpen, optionsIngameOpen ;
  
    //__________________________________________________________________//

    // OPEN/CLOSE CANVAS

    public void OpenAccueil()
    {
        if(accueilOpen == false)
        {
            Accueil.SetActive(true);
        }

        if (accueilOpen == true)
        {
            Accueil.SetActive(false);
        }
    }
    
    public void OpenMainMenu()
    {   
        if (mainMenuOpen == false)
        {
            MainMenu.SetActive(true);
        }

        if (mainMenuOpen == true)
        {
            MainMenu.SetActive(false);
        }
    }
    
    public void OpenOption()
    {
        if (optionsOpen == false)
        {
            Options.SetActive(true);
        }

        if (optionsOpen == true)
        {
            Options.SetActive(false);
        }
    }
    
    public void OpenLoadScreen()
    {
        if (loadScreenOpen == false)
        {
            LoadScreen.SetActive(true);
        }

        if (loadScreenOpen == true)
        {
            LoadScreen.SetActive(false);
        }
    }
    
    public void OpenMenuIngame()
    {
        if (menuIngameOpen == false)
        {
            MenuIngame.SetActive(true);
        }

        if (menuIngameOpen == true)
        {
            MenuIngame.SetActive(false);
        }
    }
    public void OpenOtionsIngame()
    {
        if (optionsIngameOpen == false)
        {
            OptionsIngame.SetActive(true);
        }

        if (optionsIngameOpen == true)
        {
            OptionsIngame.SetActive(false);
        }
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