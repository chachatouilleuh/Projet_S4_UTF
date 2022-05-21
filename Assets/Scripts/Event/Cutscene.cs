using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("layer du player")] private Animator m_animator;
    [SerializeField, Tooltip("layer du player")] private int m_cutsceneNumber;
    [SerializeField, Tooltip("layer du player")] private float m_waitBeforeStart;
    [SerializeField, Tooltip("layer du player")] private float m_waitBeforeEnd;
    
    [SerializeField, Tooltip("le son est deja joue")] private bool m_alreadyPlayed;

    public static bool m_isCutscene;
    private void Start()
    {
        switch (m_cutsceneNumber)
        {
            case 1:
                m_animator.GetBool("cutscene1");
                break;
            
            case 2:
                m_animator.GetBool("cutscene2");
                break;
            
            case 3:
                m_animator.GetBool("cutscene3");
                break;
            
            case 4:
                m_animator.GetBool("cutscene4");
                break;
        }
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if ((m_playerLayer.value & (1 << other.gameObject.layer)) > 0 && !m_alreadyPlayed)
        {
            m_alreadyPlayed = true;
            yield return new WaitForSeconds(m_waitBeforeStart);
            StartCutscene();
            yield return new WaitForSeconds(m_waitBeforeEnd);
            StopCutscene();
           
        }
    }
    private void StartCutscene()
    {
        m_isCutscene = true;
            
        switch (m_cutsceneNumber)
        {
            case 1:
                
                m_animator.SetBool("cutscene1",true);
                break;
            
            case 2:
                m_animator.SetBool("cutscene2", true);
                break;
            
            case 3:
                m_animator.SetBool("cutscene3", true);
                break;
                
            case 4:
                m_animator.SetBool("cutscene4", true);
                break;
        }
    }
    
    private void StopCutscene()
    {
        m_isCutscene = false;
        
        switch (m_cutsceneNumber)
        {
            case 1:
                m_animator.SetBool("cutscene1",false);
                break;
            
            case 2:
                m_animator.SetBool("cutscene2", false);
                break;
            
            case 3:
                m_animator.SetBool("cutscene3", false);
                break;
                
            case 4:
                m_animator.SetBool("cutscene4", false);
                break;
        }
    }
}
