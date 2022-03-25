using UnityEngine;

public class Pick_Object : MonoBehaviour
{
    [SerializeField, Tooltip("le layer de l'objet")] 
    private LayerMask m_pickable_Object;

    [SerializeField, Tooltip("la layer de la plaque")]
    private LayerMask m_pressPlate;
    
    [SerializeField, Tooltip("la caméra du perso")] 
    Camera fpsCam;
    
    [SerializeField, Tooltip("la range pour pick l'objet")]
    private float m_distance;
    
    [SerializeField, Tooltip("recup le transform de la 'main'")] 
    private Transform m_hand;

    [SerializeField, Tooltip("bool pour check si on porte un objet")] 
    private bool m_gotBox = false;
    
    private Rigidbody m_rigidbody;
    private Collider m_collider;
    private Transform m_transform;
    
    private void Update()
    {
        Ray pickupRay = new Ray(fpsCam.transform.position, fpsCam.transform.forward * m_distance);

        RaycastHit hit;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(pickupRay, out hit, m_distance, m_pickable_Object))
            {
                if (!m_rigidbody)
                {
                    m_rigidbody = hit.rigidbody;
                    m_collider = hit.collider;
        
                    m_rigidbody.isKinematic = true;
                    m_collider.enabled = false;

                    m_gotBox = true;
                    Debug.Log("j'ai une boite");
                }
                return;
            }
        
            // if (m_rigidbody)
            // {
            //     m_rigidbody.isKinematic = false;
            //     m_collider.enabled = true;
            //
            //     m_rigidbody = null;
            //     m_collider = null;
            //
            //     m_gotBox = false;
            //     Debug.Log("j'ai plus de boite");
            // }

            if (Physics.Raycast(pickupRay, out hit, m_distance, m_pressPlate))
            {
                if (m_gotBox == true)
                {
                    Debug.Log("j'ai pose la boite");
                    if (m_rigidbody)
                    {
                        m_transform = hit.transform;

                        // m_rigidbody.isKinematic = false;
                        // m_collider.enabled = true;
                        //
                        // m_rigidbody = null;
                        // m_collider = null;
                    
                        m_gotBox = false;
                        Debug.Log("j'ai plus de boite");
                    }
                }
                Debug.Log("j'ai pas de boite");
            }
        }

        if (m_rigidbody)
        {
            m_rigidbody.position = m_hand.position;
            m_rigidbody.rotation = m_hand.rotation;
        }
    }
}
