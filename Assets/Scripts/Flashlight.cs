using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField, Tooltip("flash active ?")] private bool m_isOn;


    private void Start()
    {
        GetComponent<Light>().enabled = false;
        m_isOn = false;
    }

    private void Update()
    {

        if (!Input.GetKeyDown(KeyCode.E)) return;
        switch (m_isOn)
        {
            case false:
                m_isOn = true;
                GetComponent<Light>().enabled = true;
                break;
            case true:
                m_isOn = false;
                GetComponent<Light>().enabled = false;
                break;
        }
    }
}
