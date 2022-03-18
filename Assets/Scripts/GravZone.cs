using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GravZone : MonoBehaviour
{
    [SerializeField, Tooltip("Gravité inversée")]
    private bool m_invertForce;
    [SerializeField, Tooltip("Force exercée par la gravité")]
    private float m_force = 0f;
    
    private void OnTriggerStay(Collider other)
    {
        if (m_invertForce)
        {
            other.attachedRigidbody.AddForce(Vector3.up * m_force);
        }
        else
        {
            other.attachedRigidbody.AddForce(Vector3.down * m_force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrée dans le champ");
        if (other.attachedRigidbody)
        {
            //other.attachedRigidbody.useGravity = false;
            
            other.transform.Rotate(1, 1, 1, Space.Self);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Sortie du champ");
        if (other.attachedRigidbody)
        {
            //other.attachedRigidbody.useGravity = true;
        }
    }
}
