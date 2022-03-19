using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

public class Raycast : MonoBehaviour
{
    [SerializeField, Tooltip("le layer de l'objet")] private LayerMask m_pickable_Object;
    [SerializeField, Tooltip("la caméra du perso")] Camera fpsCam;
    [SerializeField, Tooltip("la range pour pick l'objet")] private float m_distance;
    [SerializeField, Tooltip("recup le transform de la 'main'")] private Transform m_hand;
    [SerializeField] private GameObject m_curTarget;

    private Rigidbody m_rigidbody;
    private Collider m_collider;
    void Update()
    {
        // Vector3 m_direction = new Vector3(1f, 0f, 1f);

        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * m_distance, Color.green);
        Ray pickupRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward * m_distance);

        RaycastHit hit;

        if (Physics.Raycast(pickupRay, out hit, m_distance))
        {
            if (hit.transform.gameObject.CompareTag("Pickable_Object") || hit.transform.gameObject.CompareTag("Probes_Object"))
            {
                m_curTarget = hit.transform.gameObject;
                m_curTarget.GetComponent<Outline>().enabled = true;
            }
            else
            {
                m_curTarget.GetComponent<Outline>().enabled = false;
            }
        }
        else
        {
            // m_curTarget.GetComponent<Outline>().enabled = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(pickupRay, out hit, m_distance, m_pickable_Object))
            {
                if (!m_rigidbody)
                {
                    m_rigidbody = hit.rigidbody;
                    m_collider = hit.collider;
        
                    m_rigidbody.isKinematic = true;
                    m_collider.enabled = false;
                }
                return;
            }
        
            if (m_rigidbody)
            {
                m_rigidbody.isKinematic = false;
                m_collider.enabled = true;
            
                m_rigidbody = null;
                m_collider = null;
            }
        }
        
        if (m_rigidbody)
        {
            m_rigidbody.position = m_hand.position;
            m_rigidbody.rotation = m_hand.rotation;
        }
    }
}
