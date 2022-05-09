using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;
using UnityEngine.Audio;

public class SwitchHUD : MonoBehaviour
{
    private AudioSource m_audioSourceHUD;
    [SerializeField, Tooltip("le sfx open hud a jouer")] private AudioClip m_clipOpen;
    [SerializeField, Tooltip("le sfx close hud a jouer")] private AudioClip m_clipClose;

    private void Awake()
    {
        m_audioSourceHUD = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (FirstPersonLook.m_isOption == false)
            {
                m_audioSourceHUD.PlayOneShot(m_clipOpen);
            }
            else
            {
                m_audioSourceHUD.PlayOneShot(m_clipClose);
            }
        }
    }
}
