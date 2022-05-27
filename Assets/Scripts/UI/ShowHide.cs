using Packages.Mini_First_Person_Controller.Scripts;
using UnityEngine;

public class ShowHide : MonoBehaviour
{
    [SerializeField, Tooltip("l'animator controller")] private Animator m_animator;
    [SerializeField, Tooltip("l'animator controller")] private Animator m_otherGameObject;
    [SerializeField, Tooltip("l'animator controller")] private bool m_isArrow;

    private int m_showOrHide;
    private bool m_secondAnimator;

    private void Awake()
    {
        m_showOrHide = Animator.StringToHash("Up");
        m_secondAnimator = m_otherGameObject.GetComponent<Animator>().GetBool("Up");
        m_animator?.SetBool("Up", false);

        if (m_isArrow)
        {
            m_animator?.SetBool("isArrow", true);
        }


    }

    public void ShowOrHide()
    {
        if (m_animator.GetBool("Up") == false)
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
        else if(FirstPersonLook.m_isOption && m_isArrow && m_secondAnimator)
        {
            m_animator?.SetBool("Up", false);
        }
        else if (FirstPersonLook.m_isOption && m_isArrow && !m_secondAnimator)
        {
            m_animator?.SetBool("Up", true);
        }
    }
}



