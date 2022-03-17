using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField, Tooltip("le layer de l'objet")] private LayerMask Pickable_Object;
    [SerializeField, Tooltip("la caméra du perso")] Camera fpsCam;
    [SerializeField, Tooltip("la range pour pick l'objet")] private float m_distance;
    [SerializeField] private GameObject m_curTarget;

    private Rigidbody m_rigidbody;
    private Collider m_collider;
    void FixedUpdate()
    {
        // Vector3 m_direction = new Vector3(1f, 0f, 1f);
        Ray pickupRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward);
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * m_distance, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(pickupRay, out hit, m_distance, Pickable_Object))
        {
            if (hit.transform.gameObject.CompareTag("Pickable_Object"))
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
            m_curTarget.GetComponent<Outline>().enabled = false;
        }
    }
}
