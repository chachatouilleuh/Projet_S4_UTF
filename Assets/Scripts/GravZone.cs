using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GravZone : MonoBehaviour
{
    [Header("Gravity Properties")]
    [SerializeField, Tooltip("Canceled")]
    private bool m_noForce;
    [SerializeField, Tooltip("Intensified")]
    private bool m_addForce;
    [SerializeField, Tooltip("Inversed")]
    private bool m_invertForce;
    [SerializeField, Tooltip("Force applied")]
    private float m_force = 0f;

    private void OnTriggerStay(Collider other)
    {
        if (m_noForce)
        {
            other.attachedRigidbody.useGravity = false;
        }
        else if (m_addForce)
        {
            other.attachedRigidbody.AddForce(Vector3.down * m_force);
        }
        else if (m_invertForce)
        {
            other.attachedRigidbody.AddForce(Vector3.up * m_force);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (m_noForce)
            {
                other.attachedRigidbody.useGravity = true;
            }
        }
    }
    
    private static int Truth(params bool[] booleans)
    {
        return booleans.Count(b => b);
    }
    
    private void Start()
    {
        if (Truth(m_noForce, m_addForce, m_invertForce) > 1)
        {
            Debug.LogWarning($"{this}: Multiples properties issue");
        }
        else if (Truth(m_noForce, m_addForce, m_invertForce) < 1)
        {
            Debug.LogWarning($"{this}: No property ticked");
        }
        
        if (m_addForce || m_invertForce)
        {
            if (m_force <= 0)
            {
                Debug.LogWarning($"{this}: The force is less than or equal to 0");
            }
        }
    }
}
