using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isOn;

    private void Start()
    {
        this.GetComponent<Light>().enabled = false;
        isOn = false;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        switch (isOn)
        {
            case false:
                isOn = true;
                this.GetComponent<Light>().enabled = true;
                break;
            case true:
                isOn = false;
                this.GetComponent<Light>().enabled = false;
                break;
        }
    }
}
