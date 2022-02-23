using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Pikcup : MonoBehaviour
{
    public GameObject go;
    [SerializeField] private float m_distance;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, m_distance))
        {
            if (hit.transform.gameObject.CompareTag("Pickable_Object"))
            {
                go = hit.transform.gameObject;
                go.GetComponent<Outline>().enabled = true;
            }
            else
            {
                go.GetComponent<Outline>().enabled = false;
                go = null;
            }

            if (Input.GetMouseButtonDown(1) && go != null)
            {
                Destroy(go);
            }
        }
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * m_distance);
    }
}
