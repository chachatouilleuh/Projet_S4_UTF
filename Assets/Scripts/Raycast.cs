using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] float m_distance;
    [SerializeField] Camera fpsCam;
    [SerializeField] private GameObject m_curTarget;

    void FixedUpdate()
    {
        // Vector3 m_direction = new Vector3(1f, 0f, 1f);
        // Ray interactRay = new Ray(transform.position, m_direction);
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * m_distance, Color.green);
        
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, m_distance))
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
