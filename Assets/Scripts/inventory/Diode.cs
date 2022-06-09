using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diode : MonoBehaviour
{
    [SerializeField] private Material m_diodeOn;
    [SerializeField] private Material m_diodeOff;

    [SerializeField] private Lock m_isOpening;
    
    void Update()
    {
        if (m_isOpening.isOpening)
        {
            gameObject.GetComponent<MeshRenderer>().material = m_diodeOn;
        }
    }
}
