using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CanvasManager : MonoBehaviour
{
    //private SceneManager sceneManager;

    [SerializeField, Tooltip("les canvas à assigner")] private GameObject Accueil, MainMenu, Options, LoadScreen, HUD;
    
    private bool m_accueilOpen, m_mainMenuOpen, m_optionsOpen, m_loadScreenOpen, m_optionsIngameOpen, m_hudOpen;
    private Scene scene;

    // INITIALISE LES VALEURS
    private void Awake()
    {
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Menu":
                OpenAccueil();
                break;
            
            case "UI INGAME":
                OpenHUD();
                break;
        }
    }

    // OPEN/CLOSE CANVAS ACCORDING TO LANGUAGE SELECTION

    void Update()
    {
        if (m_accueilOpen)
        {
            if (Input.anyKey)
            {
                OpenAccueil();
                OpenMainMenu();
            }
        }
    }
    public void OpenAccueil()
    {
        if (!m_accueilOpen)
        {
            Accueil.SetActive(true);
            m_accueilOpen = true;
        }
        else
        {
            Accueil.SetActive(false);
            m_accueilOpen = false;
        }
    }
    
    public void OpenMainMenu()
    {   
        
        if (!m_mainMenuOpen)
        {
            MainMenu.SetActive(true);
            m_mainMenuOpen = true;
        }
        else
        {
            MainMenu.SetActive(false);
            m_mainMenuOpen = false;
        }
    }
    
    public void OpenOptions()
    {
        if (!m_optionsOpen)
        {
            Options.SetActive(true);
            m_optionsOpen = true;
        }
        else
        {
            Options.SetActive(false);
            m_optionsOpen = false;
        }
    }
    
    public void OpenLoadScreen()
    {
        if (!m_loadScreenOpen)
        {
            LoadScreen.SetActive(true);
            m_loadScreenOpen = true;
        }
        else
        {
            LoadScreen.SetActive(false);
            m_loadScreenOpen = false;
        }
    }
    
    public void OpenHUD()
    {
        if (!m_hudOpen)
        {
            HUD.SetActive(true);
            m_hudOpen = true;
        }
        else
        {
            HUD.SetActive(false);
            m_hudOpen = false;
        }
    }
    
    

    // A voir si l'on fait une option différente

    //public void OpenOptionsIngame()
    //{
    //    if (!m_optionsIngameOpen)
    //    {
    //        OptionsIngame.SetActive(true);
    //        m_optionsIngameOpen = true;
    //    }
    //    else
    //    {
    //        OptionsIngame.SetActive(false);
    //        m_optionsIngameOpen = false;
    //    }
    //}

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
