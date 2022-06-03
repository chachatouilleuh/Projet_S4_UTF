using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    //private SceneManager sceneManager;

    [SerializeField, Tooltip("les canvas à assigner")] private GameObject Accueil, MainMenu, Options, LoadScreen, HUD, HUDBlur, HUDBroken, HUDBrokenInside, Planet, Probes, Records, Characters, Pointeur;
    
    private bool m_accueilOpen, m_mainMenuOpen, m_optionsOpen, m_loadScreenOpen, m_hudOpen, m_planetOpen, m_probesOpen, m_recordsOpen, m_charactersOpen;
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
            
            case "Playtest":
                OpenHUD();
                break;
        }
    }

    // OPEN/CLOSE CANVAS ACCORDING TO LANGUAGE SELECTION

    void Update()
    {
        switch (scene.name)
        {
            case "Menu":
                if (m_accueilOpen)
                {
                    if (Input.anyKey)
                    {
                        OpenAccueil();
                        OpenMainMenu();
                    }
                }
                break;
            
            case "Playtest":
                if (FirstPersonLook.m_isOption == false)
                {
                    ResetLoreCanvas();
                    HUDBlur.SetActive(false);
                    if (SetActiveTrigger.m_isbroken)
                    {
                        HUDBroken.SetActive(true);
                        HUDBrokenInside.SetActive(false);
                    }
                }
                else
                {
                    HUDBlur.SetActive(true);
                    if (SetActiveTrigger.m_isbroken)
                    {
                        HUDBroken.SetActive(true);
                        HUDBrokenInside.SetActive(true);
                    }
                }
                break;
        }

        if (Cutscene.m_isCutscene)
        {
            Pointeur.SetActive(false);
        }
        else
        {
            Pointeur.SetActive(true);
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
    



}
