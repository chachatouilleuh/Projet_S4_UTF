using System.Collections;
using UnityEngine;

public class BoxEvent : MonoBehaviour
{
    [SerializeField, Tooltip("appel du trigger")]
    private Event m_triggeredEvent;

    [SerializeField, Tooltip("recup le gameobject")]
    private Rigidbody m_boxTriggered;

    [SerializeField, Tooltip("layer pont")]
    private LayerMask m_bridgeMask;

    private Coroutine m_boxEventCor;

    [SerializeField, Tooltip("temps avant de detruire objet")]
    private float m_SecondsWait;

    [SerializeField, Tooltip("destroy object ?")]
    private bool m_objetDestroy;

    private void OnEnable()
    {
        m_triggeredEvent.onTrigger += HandleTriggerEvent;
    }

    private void OnDisable()
    {
        m_triggeredEvent.onTrigger -= HandleTriggerEvent;
        
        if (m_boxEventCor != null)
        {
            StopCoroutine(m_boxEventCor);
            m_boxEventCor = null;
        }
    }

    private void HandleTriggerEvent()
    {
        m_boxTriggered.GetComponent<Rigidbody>().isKinematic = false;

        if (m_objetDestroy)
        {
            m_boxEventCor = StartCoroutine(Boxdestroy());
        }
    }

    IEnumerator Boxdestroy()
    {
        yield return new WaitForSeconds(m_SecondsWait);
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision p_collision)
    {
        if ((m_bridgeMask.value & (1 << p_collision.gameObject.layer)) > 0)
        {
            p_collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}