using Packages.QuickOutline.Scripts;
using UnityEngine;

public class SnapObjects : MonoBehaviour
{
    [SerializeField, Tooltip("Detection of the cube in the trigger")]
    private GameObject m_cubeDetect;
    
    [SerializeField, Tooltip("m_isHolding form Pick_Object")]
    private Pick_Object m_hasCube;

    [SerializeField, Tooltip("Get transform of the empty object")]
    private Transform m_snapPoint;

    [SerializeField, Tooltip("layer de l'objet a poser")]
    private LayerMask m_layerBox;

    [SerializeField, Tooltip("recup l'inventaire du player")]
    private GetProbes m_GetProbes;

    [SerializeField, Tooltip("je peux poser une box ?")]
    private bool m_activate;

    private void OnTriggerStay(Collider other)
    {
        if (m_hasCube.m_isHolding) m_cubeDetect.GetComponent<Outline>().enabled = true;

            if ((m_layerBox.value & (1 << other.gameObject.layer)) > 0)
            {
                if (!m_activate)
                {
                    other.transform.position = m_snapPoint.position;
                    other.transform.rotation = m_snapPoint.rotation;

                    other.GetComponent<Rigidbody>().isKinematic = true;
                    other.gameObject.layer = 0;
                    m_activate = true;
                }

                Plate myPlates = GetComponent<Plate>();
                if (myPlates != null && myPlates.ActivePlate(out KeyType o_plates))
                {
                    if (!m_GetProbes.m_inventaire.Contains(o_plates))
                    {
                        m_GetProbes.m_inventaire.Add(o_plates);
                    }
                }
            }
            
    }

    private void OnTriggerExit(Collider other)
    {
        m_cubeDetect.GetComponent<Outline>().enabled = false;
    }
}
