using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoTab : MonoBehaviour
{
    [SerializeField, Tooltip("le tuto tab")] private GameObject m_tutoTab;
    [SerializeField, Tooltip("le tuto lamp")] private GameObject m_tutoLamp;
    [SerializeField, Tooltip("le tuto lamp")] private GameObject m_tutoShift;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            m_tutoTab.GetComponent<TextMeshProUGUI>().text = "";
            m_tutoTab.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_tutoLamp.GetComponent<TextMeshProUGUI>().text = "";
            m_tutoLamp.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_tutoShift.GetComponent<TextMeshProUGUI>().text = "";
            m_tutoShift.SetActive(false);
        }
    }
}
