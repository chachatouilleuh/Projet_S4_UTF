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

    private Rigidbody m_rigidbody;
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(m_hasCube.m_isHolding ? "Has cube" : "Has no cube");
        
        if (m_hasCube.m_isHolding) m_cubeDetect.GetComponent<Outline>().enabled = true;

        if (m_rigidbody)
        {
            m_rigidbody.position = m_snapPoint.position;
            m_rigidbody.rotation = m_snapPoint.rotation;
            m_rigidbody.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        m_cubeDetect.GetComponent<Outline>().enabled = false;
    }
}
