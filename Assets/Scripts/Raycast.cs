using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] float m_distance;
    [SerializeField] Camera fpsCam;
    [SerializeField] private Color m_colorInteract;
    Pointeur _Pointeur;

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
                _Pointeur = transform.GetComponent<Pointeur>();
                if (_Pointeur != null)
                {
                    // _Pointeur.GetComponent<Image>().Color = m_colorInteract;
                }
            

            }


        }
        
    }
}
