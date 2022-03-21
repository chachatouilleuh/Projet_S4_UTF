using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPlate : MonoBehaviour
{
    // [SerializeField, Tooltip("l'objet voulu")]
    // private GameObject m_curObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable_Object"))
        {
            Debug.Log("l'objet la dis donc");
            
            // myObject.GetComponent<Rigidbody>().enabled = false;
        }
    }
}