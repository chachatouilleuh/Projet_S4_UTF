using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    //private SceneManager sceneManager;

    [SerializeField, Tooltip("les canvas à assigner")] private GameObject Accueil, MainMenu, Options, LoadScreen, HUD, Planet, Probes, Records, Characters;
    
    private bool m_accueilOpen, m_mainMenuOpen, m_optionsOpen, m_loadScreenOpen, m_optionsIngameOpen, m_hudOpen, m_planetOpen, m_probesOpen, m_recordsOpen, m_charactersOpen;
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

        if (FirstPersonLook.m_isOption == false)
        {
            ResetLoreCanvas();
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
    public void OpenPlanet()
    {
        if (!m_planetOpen)
        {
            Planet.SetActive(true);
            Probes.SetActive(false);
            Records.SetActive(false);
            Characters.SetActive(false);
            
            m_planetOpen = true;
            m_probesOpen = false;
            m_recordsOpen = false;
            m_charactersOpen = false;
            
        }
        else
        {
            Planet.SetActive(false);
            m_planetOpen = false;
        }
    }
    public void OpenProbes()
    {
        if (!m_probesOpen)
        {
            Planet.SetActive(false);
            Probes.SetActive(true);
            Records.SetActive(false);
            Characters.SetActive(false);
            
            m_planetOpen = false;
            m_probesOpen = true;
            m_recordsOpen = false;
            m_charactersOpen = false;
        }
        else
        {
            Probes.SetActive(false);
            m_probesOpen = false;
        }
    }
    public void OpenRecords()
    {
        if (!m_recordsOpen)
        {
            Planet.SetActive(false);
            Probes.SetActive(false);
            Records.SetActive(true);
            Characters.SetActive(false);
            
            m_planetOpen = false;
            m_probesOpen = false;
            m_recordsOpen = true;
            m_charactersOpen = false;
        }
        else
        {
            Records.SetActive(false);
            m_recordsOpen = false;
        }
    }
    public void OpenCharacters()
    {
        if (!m_charactersOpen)
        {
            Planet.SetActive(false);
            Probes.SetActive(false);
            Records.SetActive(false);
            Characters.SetActive(true);
            
            m_planetOpen = false;
            m_probesOpen = false;
            m_recordsOpen = false;
            m_charactersOpen = true;
        }
        else
        {
            Characters.SetActive(false);
            m_charactersOpen = false;
        }
    }

    public void ResetLoreCanvas()
    {
        Planet.SetActive(false);
        Probes.SetActive(false);
        Records.SetActive(false);
        Characters.SetActive(false);

        m_planetOpen = false;
        m_probesOpen = false;
        m_recordsOpen = false;
        m_charactersOpen = false;
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
