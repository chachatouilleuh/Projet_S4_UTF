using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] float m_distance;
    [SerializeField] float m_moveStrength;
    [SerializeField] Camera fpsCam;
    [SerializeField] private GameObject m_curTarget;

    [SerializeField] private Transform m_holdParent;
    [SerializeField] private GameObject m_heldObj;

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
        
        if (Input.GetMouseButton(0))
        {
            if (m_heldObj == null)
            {
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, m_distance))
                {
                    PickUpObject(hit.transform.gameObject);
                }
            }

            else
            {
                DropObject();
            }
        }

        if (m_heldObj != null)
        {
            MoveObject();
        }
    }

    void PickUpObject(GameObject p_pickObj)
    {
        if (p_pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody rb = p_pickObj.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.drag = 10;

            rb.transform.parent = m_holdParent;
            m_heldObj = p_pickObj;
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(m_heldObj.transform.position, m_holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (m_holdParent.position - m_heldObj.transform.position);
            m_heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * m_moveStrength);
        }
    }

    void DropObject()
    {
        Rigidbody rb = m_heldObj.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.drag = 1;

        m_heldObj.transform.parent = null;
        m_heldObj = null;
    }
}
