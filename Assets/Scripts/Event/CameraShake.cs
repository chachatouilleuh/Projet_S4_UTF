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

    [SerializeField, Tooltip("curve shake")]
    private AnimationCurve m_curve;

    [SerializeField, Tooltip("duration shake")]
    private float m_duration;

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
        Vector3 startPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float Strength = m_curve.Evaluate(elapsed / duration);

            transform.localPosition = startPosition + Random.insideUnitSphere * Strength;
            
            yield return null;
        }

        transform.localPosition = startPosition;
    }
}
