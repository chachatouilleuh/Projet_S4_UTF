using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CanvasManager : MonoBehaviour
{
    //private SceneManager sceneManager;

    [SerializeField, Tooltip("les canvas à assigner")] private GameObject Accueil, AccueilFr, MainMenu, MainMenuFr, Options, OptionsEn, OptionsFr, LoadScreen, MenuIngame, MenuIngameFr ;

    private bool m_accueilOpen;
    private bool m_mainMenuOpen, m_optionsOpen, m_loadScreenOpen, m_menuIngameOpen, m_optionsIngameOpen;
    

    // INITIALISE LES VALEURS
    private void Awake()
    {
        OpenAccueil();
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
            if(Underlining.m_lang == 0)
            {
                Accueil.SetActive(true);             
            }
            else
            {
                AccueilFr.SetActive(true);
            }
            m_accueilOpen = true;
        }
        else
        {
            Accueil.SetActive(false);
            AccueilFr.SetActive(false);
            m_accueilOpen = false;
        }
    }
    
    public void OpenMainMenu()
    {   
        
        if (!m_mainMenuOpen)
        {

            if (Underlining.m_lang == 0)
            {
                MainMenu.SetActive(true);
            }
            else
            {
                MainMenuFr.SetActive(true);
                
            }
            m_mainMenuOpen = true;
        }
        else
        {
            MainMenu.SetActive(false);
            MainMenuFr.SetActive(false);
            m_mainMenuOpen = false;
        }
    }
    
    public void OpenOptions()
    {
        if (!m_optionsOpen)
        {
            Options.SetActive(true);
            
            if (Underlining.m_lang == 0)
            {
                OptionsEn.SetActive(true);
            }
            else
            {
                OptionsFr.SetActive(true);
            }

            m_optionsOpen = true;
        }
        else
        {
            Options.SetActive(false);
            OptionsEn.SetActive(false);
            OptionsFr.SetActive(false);

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
    
    public void OpenMenuIngame()
    {
        if (!m_menuIngameOpen)
        {
            if(Underlining.m_lang == 0)
            {
                MenuIngame.SetActive(true);
            }
            else
            {
                MenuIngameFr.SetActive(true);
            }
            
            m_menuIngameOpen = true;
        }
        else
        {
            MenuIngame.SetActive(false);
            m_menuIngameOpen = false;
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

    // LANGUAGE CHANGING
    public void ChangeLanguage()
    {
        if (Underlining.m_lang == 0)
        {
            OptionsEn.SetActive(true);
            OptionsFr.SetActive(false);
            Debug.Log("Je suis en anglais");
        }
        else
        {
            OptionsFr.SetActive(true);
            OptionsEn.SetActive(false);
            Debug.Log("Je suis en français");
        }
    }

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