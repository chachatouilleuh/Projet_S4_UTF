using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class GravZone : MonoBehaviour
{
    [Header("Gravity Properties")]

    [SerializeField, Tooltip("Add force to +X")]
    private bool m_plusX;
    [SerializeField, Tooltip("Add force to -X")]
    private bool m_minusX;
    
    [SerializeField, Tooltip("Add force to -Y")]
    private bool m_plusY;
    [SerializeField, Tooltip("Add force to -Y")]
    private bool m_minusY;

    [SerializeField, Tooltip("Add force to +Z")]
    private bool m_plusZ;
    [SerializeField, Tooltip("Add force to -Z")]
    private bool m_minusZ;

    [SerializeField, Tooltip("Force applied to rigidbody, about 15 to propel")]
    private float m_intensity = 0f;
    
    [Header("Disabling gravity")]
    
    [SerializeField, Tooltip("Things are floating")]
    private bool m_noForce;

    private void OnTriggerStay(Collider other)
    {
        if (m_plusX) other.attachedRigidbody.AddForce(Vector3.right * m_intensity);
        if (m_minusX) other.attachedRigidbody.AddForce(Vector3.left * m_intensity);
        if (m_plusY) other.attachedRigidbody.AddForce(Vector3.up * m_intensity);
        if (m_minusY) other.attachedRigidbody.AddForce(Vector3.down * m_intensity);
        if (m_plusZ) other.attachedRigidbody.AddForce(Vector3.forward * m_intensity);
        if (m_minusZ) other.attachedRigidbody.AddForce(Vector3.back * m_intensity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_noForce) other.attachedRigidbody.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    { 
        if (m_noForce) other.attachedRigidbody.useGravity = true;
    }
    
    private static int Truth(params bool[] booleans)
    {
        return booleans.Count(b => b);
    }
    
    private void Start()
    {
        if (Truth(m_noForce, m_plusX, m_minusX, m_plusY, m_minusY, m_plusZ, m_minusZ) < 1)
        {
            Debug.LogWarning($"{this}: No property ticked");
            return;
        }
        
        if (m_minusY)
        {
            if (m_intensity <= 0)
            {
                Debug.LogWarning($"{this}: The force is less than or equal to 0");
            }
        }
    }
}
