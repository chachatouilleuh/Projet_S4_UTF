using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Pikcup : MonoBehaviour
{
    public GameObject curTarget;
    ///[SerializeField] private float m_distance;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Mathf.Infinity, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.CompareTag("Pickable_Object"))
            {
                curTarget = hit.transform.gameObject;
                curTarget.GetComponent<Outline>().enabled = true;
            }
            else
            {
                curTarget.GetComponent<Outline>().enabled = false;
                // curTarget = null;
            }

            if (Input.GetMouseButtonDown(1) && curTarget != null)
            {
                Destroy(curTarget);
            }
        }
    }
}
