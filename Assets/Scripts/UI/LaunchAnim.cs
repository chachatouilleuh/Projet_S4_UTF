using System.Collections;
using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;

public class LaunchAnim : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("l'animator controller")] private Animator m_animatorToSet;
    

    [SerializeField, Tooltip("le temps d'attente")] private float m_waitBeforeStart;
    [SerializeField, Tooltip("le temps d'attente")] private float m_waitBeforeEnd;

    private bool m_objectCollected;
    private bool m_alreadyPlayed;

    private void Update()
    {
        if (FirstPersonLook.m_isOption == false)
        {
            m_animatorToSet.SetBool("Activated", false);
        }
        else
        {
            m_animatorToSet.SetBool("Activated", true);
        }

        if (m_objectCollected)
        {
            StartCoroutine(AnimateCircle());
        }
    }


    private IEnumerator AnimateCircle()
    {
        m_alreadyPlayed = true;
        yield return new WaitForSeconds(m_waitBeforeStart);
        m_animatorToSet.SetBool("Activated", true);

        yield return new WaitForSeconds(m_waitBeforeEnd);
        m_animatorToSet.SetBool("Activated", false);
        m_objectCollected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0 && !m_alreadyPlayed)
        {
            m_objectCollected = true;
        }
    }

}



