using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChimaeraNumber : MonoBehaviour
{
    [SerializeField, Tooltip("l'animator du gameobject")] private Animator m_animator;
    [SerializeField, Tooltip("le numéro de la chimère")] private int m_chimaeraNumber;

    [SerializeField, Tooltip("la chimère est un acolyte")] private bool m_isAcolyte;
    [SerializeField, Tooltip("le numéro de l'acolyte")] private int m_acolyteNumber;

    [SerializeField, Tooltip("le temps avant que la chimère attaque")] private float m_attackTime;


    void Start()
    {
        switch (m_chimaeraNumber)
        {
            case 1:
                m_animator.SetBool("chimere1", true);
                break;

            case 2:
                m_animator.SetBool("chimere2", true);
                break;

            case 3:
                m_animator.SetBool("chimere3", true);
                break;

            case 4:
                m_animator.SetBool("chimere4", true);
                break;

            case 5:
                m_animator.SetBool("chimere5", true);
                break;
        }

        if (m_isAcolyte)
        {
            switch (m_acolyteNumber)
            {
                case 1:
                    m_animator.SetBool("acolyte1", true);
                    break;

                case 2:
                    m_animator.SetBool("acolyte2", true);
                    break;
            }
        }
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(m_attackTime);
        m_animator.SetBool("attacking", true);
    }
}
