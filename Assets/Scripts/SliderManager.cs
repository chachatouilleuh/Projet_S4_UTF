using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    // Les sources musique, sfx et luminosit�
    [SerializeField, Tooltip("la musique � mettre")] private AudioSource m_audioSource;
    [SerializeField, Tooltip("les sfx � mettre")] private AudioSource m_sfxSource;
    [SerializeField, Tooltip("les sfx � mettre")] private AudioSource m_luminositySource;

    // les Sliders
    [SerializeField, Tooltip("le slider de la musique")] private Slider m_musicSlider;
    [SerializeField, Tooltip("le slider des sfx")] private Slider m_sfxSlider;
    [SerializeField, Tooltip("le slider de la luminosit�")] private Slider m_luminositySlider;

    // la valeur maximale par d�faut assign�e
    private float m_musicVolume = 1f;
    private float m_sfxVolume = 1f;
    private float m_luminosity = 1f;

    private void Start()
    {
        // Je lance la musique
        //AudioSource.Play();

        // Au lancement du jeu je vais r�cup�rer les valeurs de mes sliders
        m_musicVolume = PlayerPrefs.GetFloat("music");
        m_sfxVolume = PlayerPrefs.GetFloat("sfx");
        m_luminosity = PlayerPrefs.GetFloat("luminosity");


        // la valeur de ma source est �gale � celle du volume r�cup�r�
        m_audioSource.volume = m_musicVolume;
        m_sfxSource.volume = m_sfxVolume;
        // EN COURS pour la luminosit� il faut trouver sa value � modifier
        m_luminositySource.volume = m_luminosity;


        // la valeur du slider est �gale � celle du volume r�cup�r�
        m_musicSlider.value = m_musicVolume;
        m_sfxSlider.value = m_sfxVolume;
        m_luminositySlider.value = m_luminosity;


       // J'initie mes valeurs par d�faut
        m_audioSource.volume = 0.5f;
        m_sfxSource.volume = 0.5f;
        // EN COURS pour la luminosit� il faut trouver sa value � modifier
        m_luminositySource.volume = 0.5f;
    }

    private void Update()
    {
        // Mes valeurs de volumes sont toujours �gales � celles r�cup�r�es
        m_audioSource.volume = m_musicVolume;
        m_sfxSource.volume = m_sfxVolume;
        // EN COURS pour la luminosit� il faut trouver sa value � modifier
        m_luminositySource.volume = m_luminosity;


        // Je remplace les valeurs r�cup�rables
        PlayerPrefs.SetFloat("music", m_musicVolume);
        PlayerPrefs.SetFloat("sfx", m_sfxVolume);
        PlayerPrefs.SetFloat("luminosit�", m_luminosity);
    }

    // Les fonctions � attribuer aux sliders pour mettre � jour les diff�rentes valeurs 

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

        // EN COURS pour la luminosit� il faut trouver sa value � modifier
        m_luminositySource.volume = 1;

        m_luminositySlider.value = 1;
    }
}