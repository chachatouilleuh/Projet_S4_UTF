using Packages.QuickOutline.Scripts;
using UnityEngine;

public class SnapObjects : MonoBehaviour
{

    [SerializeField, Tooltip("Get transform of the empty object")]
    private Transform m_snapPoint;

    [SerializeField, Tooltip("layer de l'objet a poser")]
    private LayerMask m_layerBox;
    
    [SerializeField, Tooltip("trigger de l'event")]
    private Event m_triggeredEvent;

    [SerializeField, Tooltip("recup l'inventaire du player")]
    private GetProbes m_GetProbes;

    [SerializeField, Tooltip("je peux poser une box ?")]
    private bool m_activate;
    
    
    [SerializeField, Tooltip("animation de la plaque")]
    private Animator m_animator;

    private string m_openTriggerName = "Active";
    private int m_openHash;

    private void Awake()
    {
        if (m_animator == null)
        {
            m_animator = GetComponent<Animator>();
            if (m_animator == null)
            {
                throw new System.ArgumentNullException();
            }
        }
        m_openHash = Animator.StringToHash(m_openTriggerName);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if ((m_layerBox.value & (1 << other.gameObject.layer)) > 0)
        {
            if (!m_activate)
            {
                other.transform.position = m_snapPoint.position;
                other.transform.rotation = m_snapPoint.rotation;
                other.gameObject.layer = 0;
                m_activate = true;
                m_animator?.SetTrigger(m_openHash);
                other.GetComponent<Rigidbody>().isKinematic = true;
            }

            Plate myPlates = GetComponent<Plate>();
            if (myPlates != null && myPlates.ActivePlate(out KeyType o_plates))
            {
                if (!m_GetProbes.m_inventaire.Contains(o_plates))
                {
                    m_GetProbes.m_inventaire.Add(o_plates);
                    m_triggeredEvent.Raise(m_GetProbes.m_inventaire);
                }
            }
        }
    }
}
