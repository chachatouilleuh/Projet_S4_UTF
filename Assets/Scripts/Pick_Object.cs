using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;

public class Pick_Object : MonoBehaviour
{
    [SerializeField, Tooltip("le layer de l'objet")]
    private LayerMask m_pickable_Object;

    [SerializeField, Tooltip("layer object collision problem")]
    private LayerMask m_collisionLayer;

    [SerializeField, Tooltip("la caméra du perso")]
    Camera fpsCam;
    
    [SerializeField, Tooltip("la range pour pick l'objet")]
    private float m_distance;
    
    [SerializeField, Tooltip("la range pour poser l'objet")]
    private float m_distanceDrop;
    
    [SerializeField, Tooltip("Punch force")]
    private float m_punch;
    
    [SerializeField, Tooltip("recup le transform de la 'main'")]
    private Transform m_hand;

    [SerializeField, Tooltip("canvas affiché")]
    private GameObject m_infoDropthrow;
    
    private Rigidbody m_rigidbody;
    private Collider m_collider;

    public bool m_isHolding;
    
    private void Update()
    {
        if(FirstPersonLook.m_isOption == false)
        {
            Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * m_distanceDrop, Color.green);
        
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
                        m_rigidbody.useGravity = true;
                        m_collider.enabled = false;

                        m_isHolding = true;
                        m_infoDropthrow.SetActive(true);
                    }
                    return;
                }

                if (Physics.Raycast(pickupRay, out hit, m_distanceDrop, m_collisionLayer))
                {
                    if (m_rigidbody)
                    {
                        // m_rigidbody.isKinematic = false;
                        m_collider.enabled = true;
                
                        m_rigidbody = null;
                        m_collider = null;
                
                        m_isHolding = false;
                        m_infoDropthrow.SetActive(false);
                    }
                }
                else
                {
                    if (m_rigidbody)
                    {
                        m_rigidbody.isKinematic = false;
                        m_collider.enabled = true;
                
                        m_rigidbody = null;
                        m_collider = null;
                
                        m_isHolding = false;
                        m_infoDropthrow.SetActive(false);
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(pickupRay, out hit, m_distanceDrop, m_collisionLayer))
                {
                    if (m_rigidbody)
                    {
                        // m_rigidbody.isKinematic = false;
                        m_collider.enabled = true;
                
                        m_rigidbody = null;
                        m_collider = null;
                
                        m_isHolding = false;
                        m_infoDropthrow.SetActive(false);
                    }
                }
                else
                {
                    m_rigidbody.isKinematic = false;
                    m_collider.enabled = true;
                
                    m_rigidbody.AddForce(m_hand.transform.forward * m_punch);

                    m_rigidbody = null;
                    m_collider = null;

                    m_isHolding = false;
                    m_infoDropthrow.SetActive(false);
                }
            }
        
            if (m_rigidbody)
            {
                m_rigidbody.position = m_hand.position;
                m_rigidbody.rotation = m_hand.rotation;
            } 
        }
    }
}
