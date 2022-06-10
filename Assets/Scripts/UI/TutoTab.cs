using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoTab : MonoBehaviour
{
    [SerializeField, Tooltip("le tuto tab")] private GameObject m_tutoTab;
    [SerializeField, Tooltip("le tuto lamp")] private GameObject m_tutoLamp;
    [SerializeField, Tooltip("le tuto lamp")] private GameObject m_tutoShift;
    [SerializeField, Tooltip("le tuto lamp")] private GameObject m_tutoSkip;
    void Update()
    {
        if (m_tutoTab.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                m_tutoTab.SetActive(false);
            }
            else
            {
                StartCoroutine(TutoTabCo());
            }
            
        }

        if (m_tutoLamp.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_tutoLamp.SetActive(false);
            }
            else
            {
                StartCoroutine(TutoLampCo());  
            }
            
        }

        if (m_tutoShift.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                m_tutoShift.SetActive(false);
            }
            else
            {
                StartCoroutine(TutoShiftCo());
            }
        }

        if (m_tutoSkip.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_tutoSkip.SetActive(false);
            }
            else
            {
                StartCoroutine(TutoSpaceCo()); 
            }
        }
        
        
  
    }


    IEnumerator TutoTabCo()
    {
        yield return new WaitForSeconds(10);
        m_tutoTab.SetActive(false);
    }
    
    IEnumerator TutoLampCo()
    {
        yield return new WaitForSeconds(5);
        m_tutoLamp.SetActive(false);
    }
    
    IEnumerator TutoShiftCo()
    {
        yield return new WaitForSeconds(5);
        m_tutoShift.SetActive(false);
    }
    
    IEnumerator TutoSpaceCo()
    {
        yield return new WaitForSeconds(15);
        m_tutoSkip.SetActive(false);
    }
    
}
