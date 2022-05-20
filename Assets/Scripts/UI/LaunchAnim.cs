using System;
using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;

public class LaunchAnim : MonoBehaviour
{
    [SerializeField, Tooltip("l'animator controller")] private Animator m_animatorToSet;
    //private int m_animToHash;
    
    //private void Start()
    //{
    //    m_animToHash = Animator.StringToHash("Activated");
    //}

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
    }
}



