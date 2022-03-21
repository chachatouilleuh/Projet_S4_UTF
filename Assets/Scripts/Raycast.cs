using Packages.QuickOutline.Scripts;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField, Tooltip("le layer de l'objet")] private LayerMask m_oultine_Object;
    [SerializeField, Tooltip("la caméra du perso")] Camera fpsCam;
    [SerializeField, Tooltip("la range pour pick l'objet")] private float m_distance;
    [SerializeField, Tooltip("recup le transform de la 'main'")] private Transform m_hand;
    [SerializeField] private GameObject m_curTarget;

    private Rigidbody m_rigidbody;
    private Collider m_collider;
    void Update()
    {
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * m_distance, Color.green);
        
        Ray pickupRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward * m_distance);
        RaycastHit hit;

        if (Physics.Raycast(pickupRay, out hit, m_distance, m_oultine_Object))
        {
            if (hit.transform.gameObject)
            {
                m_curTarget = hit.transform.gameObject;
                m_curTarget.GetComponent<Outline>().enabled = true;
            }
            else
            {
                m_curTarget.GetComponent<Outline>().enabled = false;
                return;
            }

        }
        else
        {
            if (m_curTarget == null)
            {
                return;
            }
            m_curTarget.GetComponent<Outline>().enabled = false;
        }
    }
}
