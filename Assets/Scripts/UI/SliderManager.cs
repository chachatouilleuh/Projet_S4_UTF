using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;

public class SliderManager : MonoBehaviour
{
    // Les sources musique et fx 
    [SerializeField, Tooltip("l'audio mixer de musique a mettre")] private AudioMixer m_audioMixer;

    // le post process pour la luminosite
    [SerializeField, Tooltip("la camera qui a le post process")] private GameObject m_cam;
    [SerializeField, Tooltip("le gameobject de post process a mettre")] private PostProcessVolume m_luminositySource;
    [SerializeField, Tooltip("l'override de post process a mettre")] private ColorGrading m_colorGrading;

    // les Sliders
    [SerializeField, Tooltip("le slider de la musique")] private Slider m_musicSlider;
    [SerializeField, Tooltip("le slider des sfx")] private Slider m_sfxSlider;
    [SerializeField, Tooltip("le slider de la luminosite")] private Slider m_luminositySlider;

    // la valeur maximale par defaut assignee
    private float m_musicVolume;
    private float m_sfxVolume;
    private float m_luminosity;

    private void Start()
    {
        // Je recupere le post process dans la camera et j'active sa modification
        m_luminositySource = m_cam.GetComponent<PostProcessVolume>();
        m_luminositySource.profile.TryGetSettings(out m_colorGrading);
        m_colorGrading.enabled.value = true;

        
        // Au lancement du jeu je vais recuperer les valeurs de mes sliders
        m_musicVolume = PlayerPrefs.GetFloat("music");
        m_sfxVolume = PlayerPrefs.GetFloat("sfx");
        m_luminosity = PlayerPrefs.GetFloat("luminosity");

        // la valeur du slider est egale a celle du volume recupere
        m_musicSlider.value = m_musicVolume;
        m_sfxSlider.value = m_sfxVolume;
        m_luminositySlider.value = m_luminosity;
        
        // J'inite la valeur de base du volume de la musique
        m_musicSlider.value = 0.5f;
        m_sfxSlider.value = 0.5f;
    }

    private void Update()
    {
        // Mes valeurs de volumes sont toujours egales a celles recuperees
        m_audioMixer.SetFloat("musicVolume", Mathf.Log10(m_musicVolume)*20);
        m_audioMixer.SetFloat("sfxVolume",Mathf.Log10(m_sfxVolume)*20);
        m_colorGrading.postExposure.value = m_luminosity;
        

        // Je remplace les valeurs recuperables
        PlayerPrefs.SetFloat("music", m_musicVolume);
        PlayerPrefs.SetFloat("sfx", m_sfxVolume);
        PlayerPrefs.SetFloat("luminosity", m_luminosity);
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

        m_audioMixer.SetFloat("musicVolume", 1);
        m_audioMixer.SetFloat("sfxVolume",1);

        m_musicSlider.value = 1;
        m_sfxSlider.value = 1;
    }
    public void LuminosityReset()
    {
        PlayerPrefs.DeleteKey("luminosity");

        m_colorGrading.postExposure.value = 0;
        m_luminositySlider.value = 0;
    }
}