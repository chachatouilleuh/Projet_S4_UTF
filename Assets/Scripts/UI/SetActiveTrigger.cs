using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("le game object à activer / desactiver")] private GameObject m_objectToActivate;

    [SerializeField, Tooltip("les interrupteurs")] private bool m_interrupteurOn, m_isHUDBroken;

    public static bool m_isbroken;


    private void OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (m_interrupteurOn)
            {
                m_objectToActivate.SetActive(false);
                m_interrupteurOn = false;
            }
            else
            {
                m_objectToActivate.SetActive(true);
                m_interrupteurOn = true;
            }

            if (m_isHUDBroken)
            {
                m_isbroken = true;
            }
        }
    }

}
