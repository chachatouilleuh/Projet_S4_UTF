using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField, Tooltip("flash active ?")] private bool m_isOn;
    [SerializeField, Tooltip("layer gravityFields")] private LayerMask m_fieldLayer;
    [SerializeField, Tooltip("la caméra du perso")] Camera fpsCam;
    [SerializeField, Tooltip("la range pour pick l'objet")] private float m_distance;
    [SerializeField] private GameObject m_curField;
    [SerializeField] private MeshCollider m_curFieldComp;

    private float m_zoneIntensity;
    

    private void Start()
    {
        GetComponent<Light>().enabled = false;
        m_isOn = false;
    }

    private void Update()
    {
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * m_distance, Color.green);
        Ray pickupRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward * m_distance);
        RaycastHit hit;
        
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

        if (Physics.Raycast(pickupRay, out hit, m_distance, m_fieldLayer))
        {
            if (hit.transform.gameObject)
            {
                m_curField = hit.transform.gameObject;

                Debug.Log(m_curFieldComp);
                if (m_isOn)
                {
                    Debug.Log("1");
                    m_zoneIntensity = m_curField.GetComponent<GravZone>().m_intensity;
                    m_curField.GetComponent<GravZone>().m_intensity = 0;
                }
                
                if(!m_isOn)
                {
                    Debug.Log("2");
                    m_curField.GetComponent<GravZone>().m_intensity = m_zoneIntensity;
                }
            }
        }
    }
}
