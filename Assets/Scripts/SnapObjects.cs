using System;
using System.Collections;
using System.Collections.Generic;
using Packages.QuickOutline.Scripts;
using UnityEngine;

public class SnapObjects : MonoBehaviour
{
    [SerializeField, Tooltip("Detection of the cube in the trigger")]
    private GameObject m_cubeDetect;
    
    [SerializeField, Tooltip("m_isHolding form Pick_Object")]
    private Pick_Object m_hasCube;

    [SerializeField, Tooltip("Get transform of the empty object")]
    private Transform m_snapPoint;

    [SerializeField, Tooltip("layer de l'objet a poser")]
    private LayerMask m_layerBox;

    private void OnTriggerStay(Collider other)
    {
        if (m_hasCube.m_isHolding) m_cubeDetect.GetComponent<Outline>().enabled = true;
        
        if ((m_layerBox.value & (1 << other.gameObject.layer)) > 0)
        {
            other.transform.position = m_snapPoint.position;
            other.transform.rotation = m_snapPoint.rotation;

            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_cubeDetect.GetComponent<Outline>().enabled = false;
    }
}
