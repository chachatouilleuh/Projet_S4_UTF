using System;
using UnityEngine;

public class SetMotionMultiplier : MonoBehaviour
{
    private Animator m_animator;
    [SerializeField, Tooltip("l'animator du trigger")] private float m_triggerNumber;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        
        switch (m_triggerNumber)
        {
            case 1:
                m_animator.SetBool("Trigger1", true);
                break;
            
            case 2:
                m_animator.SetBool("Trigger2", true);
                break;
            
            case 3:
                m_animator.SetBool("Trigger3", true);
                break;
            
            case 4:
                m_animator.SetBool("Trigger4", true);
                break;
            
            case 5:
                m_animator.SetBool("Trigger5", true);
                break;
            
            case 6:
                m_animator.SetBool("Trigger6", true);
                break;
            
            case 7:
                m_animator.SetBool("Trigger7", true);
                break;
            
            case 8:
                m_animator.SetBool("Trigger8", true);
                break;
            
            case 9:
                m_animator.SetBool("Trigger9", true);
                break;
            
            case 10:
                m_animator.SetBool("Trigger10", true);
                break;
            
            case 11:
                m_animator.SetBool("Trigger11", true);
                break;
        }
    }
    
}
