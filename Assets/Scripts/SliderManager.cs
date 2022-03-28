using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    // Les sources musique, sfx et luminosité
    [SerializeField, Tooltip("la musique à mettre")] private AudioSource m_audioSource;
    [SerializeField, Tooltip("les sfx à mettre")] private AudioSource m_sfxSource;
    [SerializeField, Tooltip("les sfx à mettre")] private AudioSource m_luminositySource;

    // les Sliders
    [SerializeField, Tooltip("le slider de la musique")] private Slider m_musicSlider;
    [SerializeField, Tooltip("le slider des sfx")] private Slider m_sfxSlider;
    [SerializeField, Tooltip("le slider de la luminosité")] private Slider m_luminositySlider;

    // la valeur maximale par défaut assignée
    private float m_musicVolume = 1f;
    private float m_sfxVolume = 1f;
    private float m_luminosity = 1f;

    private void Start()
    {
        // Je lance la musique
        //AudioSource.Play();

        // Au lancement du jeu je vais récupérer les valeurs de mes sliders
        m_musicVolume = PlayerPrefs.GetFloat("music");
        m_sfxVolume = PlayerPrefs.GetFloat("sfx");
        m_luminosity = PlayerPrefs.GetFloat("luminosity");


        // la valeur de ma source est égale à celle du volume récupéré
        m_audioSource.volume = m_musicVolume;
        m_sfxSource.volume = m_sfxVolume;
        // EN COURS pour la luminosité il faut trouver sa value à modifier
        m_luminositySource.volume = m_luminosity;


        // la valeur du slider est égale à celle du volume récupéré
        m_musicSlider.value = m_musicVolume;
        m_sfxSlider.value = m_sfxVolume;
        m_luminositySlider.value = m_luminosity;


       // J'initie mes valeurs par défaut
        m_audioSource.volume = 0.5f;
        m_sfxSource.volume = 0.5f;
        // EN COURS pour la luminosité il faut trouver sa value à modifier
        m_luminositySource.volume = 0.5f;
    }

    private void Update()
    {
        // Mes valeurs de volumes sont toujours égales à celles récupérées
        m_audioSource.volume = m_musicVolume;
        m_sfxSource.volume = m_sfxVolume;
        // EN COURS pour la luminosité il faut trouver sa value à modifier
        m_luminositySource.volume = m_luminosity;


        // Je remplace les valeurs récupérables
        PlayerPrefs.SetFloat("music", m_musicVolume);
        PlayerPrefs.SetFloat("sfx", m_sfxVolume);
        PlayerPrefs.SetFloat("luminosité", m_luminosity);
    }

    // Les fonctions à attribuer aux sliders pour mettre à jour les différentes valeurs 

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

        // EN COURS pour la luminosité il faut trouver sa value à modifier
        m_luminositySource.volume = 1;

        m_luminositySlider.value = 1;
    }
}