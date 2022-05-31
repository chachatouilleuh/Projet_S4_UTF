using Packages.QuickOutline.Scripts;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField, Tooltip("le layer de l'objet")] private LayerMask m_oultine_Object;
    [SerializeField, Tooltip("la caméra du perso")] Camera fpsCam;
    [SerializeField, Tooltip("la range pour pick l'objet")] private float m_distance;
    [SerializeField] private GameObject m_curTarget;

    [SerializeField, Tooltip("canvas affiché")] private GameObject m_infoCube;
    void Update()
    {
        
        
        Ray pickupRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward * m_distance);
        RaycastHit hit;

        if (Physics.Raycast(pickupRay, out hit, m_distance, m_oultine_Object))
        {
            if (hit.transform.gameObject)
            {
                m_curTarget = hit.transform.gameObject;
                m_curTarget.GetComponent<Outline>().enabled = true;
                // m_curTarget.GetComponentInChildren<Outline>().enabled = true;
                m_infoCube.SetActive(true);
            }
            else
            {
                m_curTarget.GetComponent<Outline>().enabled = false;
                // m_curTarget.GetComponentInChildren<Outline>().enabled = false;
                m_infoCube.SetActive(false);
            }

        }
        else
        {
            if (m_curTarget == null)
            {
                return;
            }
            m_curTarget.GetComponent<Outline>().enabled = false;
            // m_curTarget.GetComponentInChildren<Outline>().enabled = false;
            m_infoCube.SetActive(false);
        }
    }
}
