using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Serialization;


public class SliderManager : MonoBehaviour
{
    // Les sources musique, sfx et luminosite
    [SerializeField, Tooltip("la musique a mettre")] private AudioSource m_audioSource;
    [SerializeField, Tooltip("les sfx a mettre")] private AudioSource m_sfxSource;
    [SerializeField, Tooltip("le layer de post process a mettre")] private Light m_luminositySource;

    // les Sliders
    [SerializeField, Tooltip("le slider de la musique")] private Slider m_musicSlider;
    [SerializeField, Tooltip("le slider des sfx")] private Slider m_sfxSlider;
    [SerializeField, Tooltip("le slider de la luminosite")] private Slider m_luminositySlider;

    // la valeur maximale par defaut assignee
    private float m_musicVolume = 1f;
    private float m_sfxVolume = 1f;
    private float m_luminosity = 1f;

    private void Start()
    {
        // Je lance la musique
        //AudioSource.Play();

        // Au lancement du jeu je vais recuperer les valeurs de mes sliders
        m_musicVolume = PlayerPrefs.GetFloat("music");
        m_sfxVolume = PlayerPrefs.GetFloat("sfx");
        m_luminosity = PlayerPrefs.GetFloat("luminosity");
        
        // la valeur de ma source est egale a celle du volume recupere
        m_audioSource.volume = m_musicVolume;
        m_sfxSource.volume = m_sfxVolume;
        m_luminositySource.intensity = m_luminosity;

        // la valeur du slider est egale a celle du volume recupere
        m_musicSlider.value = m_musicVolume;
        m_sfxSlider.value = m_sfxVolume;
        m_luminositySlider.value = m_luminosity;
        
       // J'initie mes valeurs par defaut
        m_audioSource.volume = 0.5f;
        m_sfxSource.volume = 0.5f;
        m_luminositySource.intensity = 0.5f;
    }

    private void Update()
    {
        // Mes valeurs de volumes sont toujours egales a celles recuperees
        m_audioSource.volume = m_musicVolume;
        m_sfxSource.volume = m_sfxVolume;
        m_luminositySource.intensity = m_luminosity;


        // Je remplace les valeurs recuperables
        PlayerPrefs.SetFloat("music", m_musicVolume);
        PlayerPrefs.SetFloat("sfx", m_sfxVolume);
        PlayerPrefs.SetFloat("luminosite", m_luminosity);
    }

    // Les fonctions a attribuer aux sliders pour mettre a jour les differentes valeurs 

    public void MusicVolumeUpdater(float volume)
    {
        m_musicVolume = volume;
    }
    public void SFXVolumeUpdater(float volume)
    {
        m_sfxVolume = volume;
    }
    public void LuminosityUpdater(float value)
    {
        m_luminosity = value;
    }


    // Les fonctions pour reset les valeurs

    public void VolumeReset()
    {
        PlayerPrefs.DeleteKey("music");
        PlayerPrefs.DeleteKey("sfx");

        m_audioSource.volume = 1;
        m_sfxSource.volume = 1;

        m_musicSlider.value = 1;
        m_sfxSlider.value = 1;
    }
    public void LuminosityReset()
    {
        PlayerPrefs.DeleteKey("luminosity");

        m_luminositySource.intensity = 1;
        m_luminositySlider.value = 1;
    }
}