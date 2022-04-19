using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;


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
}



