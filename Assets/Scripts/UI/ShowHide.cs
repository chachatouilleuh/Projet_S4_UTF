using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    [SerializeField, Tooltip("l'animator controller")] private Animator m_animator;
    private int m_showOrHide;

    private void Awake()
    {
        m_showOrHide = Animator.StringToHash("Up");
    }

    public void ShowOrHide()
    {
        if (m_animator.GetBool("Up") == false )
        {
            m_animator?.SetBool("Up", true);
        }
        else
        {
            m_animator?.SetBool("Up", false);
        }
    }

    private void Update()
    {
        if (FirstPersonLook.m_isOption == false)
        {
            m_animator?.SetBool("Up", false);
        }
    }
}



