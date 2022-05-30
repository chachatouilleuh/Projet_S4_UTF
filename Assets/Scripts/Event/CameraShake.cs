using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    [SerializeField, Tooltip("appel du trigger")]
    private Event m_triggeredEvent;

    private Coroutine m_shakeCam;

    private void OnEnable()
    {
        m_triggeredEvent.onTrigger += HandleTriggerEvent;
    }

    private void OnDisable()
    {
        m_triggeredEvent.onTrigger -= HandleTriggerEvent;
        
        if (m_shakeCam != null)
        {
            StopCoroutine(m_shakeCam);
            m_shakeCam = null;
        }
    }

    private void HandleTriggerEvent()
    {
        m_shakeCam = StartCoroutine(Shake(4f, 0.1f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
