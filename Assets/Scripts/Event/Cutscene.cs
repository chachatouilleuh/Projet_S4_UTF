using System.Collections;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField, Tooltip("layer du player")] private LayerMask m_playerLayer;
    [SerializeField, Tooltip("l'animator du gameobject")] private Animator m_animator;
    [SerializeField, Tooltip("l'animator d'un deuxième perso ")] private Animator m_secondCharacterAnimator;
    [SerializeField, Tooltip("le numéro de la cutscene")] private int m_cutsceneNumber;
    [SerializeField, Tooltip("l'attente avant de lancer la cutscene")] private float m_waitBeforeStart;
    [SerializeField, Tooltip("layer du player")] private float m_waitBeforeEnd;
    
    [SerializeField, Tooltip("le son est deja joue")] private bool m_alreadyPlayed;

    public static bool m_isCutscene;
    private void Start()
    {
        switch (m_cutsceneNumber)
        {
            case 1:
                m_animator.GetBool("cutscene1");
                m_secondCharacterAnimator.GetBool("cutscene1");
                break;
            
            case 2:
                m_animator.GetBool("cutscene2");
                m_secondCharacterAnimator.GetBool("cutscene2");
                break;
            
            case 3:
                m_animator.GetBool("cutscene3");
                m_secondCharacterAnimator.GetBool("cutscene3");
                break;
            
            case 4:
                m_animator.GetBool("cutscene4");
                m_secondCharacterAnimator.GetBool("cutscene4");
                break;
            
            case 5:
                m_animator.GetBool("cutscene5");
                m_secondCharacterAnimator.GetBool("cutscene5");
                break;
            
            case 6:
                m_animator.GetBool("cutscene5");
                m_secondCharacterAnimator.GetBool("cutscene6");
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
                m_secondCharacterAnimator.SetBool("cutscene1",true);
                break;
            
            case 2:
                m_animator.SetBool("cutscene2", true);
                m_secondCharacterAnimator.SetBool("cutscene2",true);
                break;
            
            case 3:
                m_animator.SetBool("cutscene3", true);
                m_secondCharacterAnimator.SetBool("cutscene3",true);
                break;
                
            case 4:
                m_animator.SetBool("cutscene4", true);
                m_secondCharacterAnimator.SetBool("cutscene4",true);
                break;
            
            case 5:
                m_animator.SetBool("cutscene5", true);
                m_secondCharacterAnimator.SetBool("cutscene5",true);
                break;
            
            case 6:
                m_animator.SetBool("cutscene6", true);
                m_secondCharacterAnimator.SetBool("cutscene6",true);
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
                m_secondCharacterAnimator.SetBool("cutscene1",false);
                break;
            
            case 2:
                m_animator.SetBool("cutscene2", false);
                m_secondCharacterAnimator.SetBool("cutscene2",false);
                break;
            
            case 3:
                m_animator.SetBool("cutscene3", false);
                m_secondCharacterAnimator.SetBool("cutscene3",false);
                break;
                
            case 4:
                m_animator.SetBool("cutscene4", false);
                m_secondCharacterAnimator.SetBool("cutscene4",false);
                break;
            
            case 5:
                m_animator.SetBool("cutscene5", false);
                m_secondCharacterAnimator.SetBool("cutscene5",false);
                break;
            
            case 6:
                m_animator.SetBool("cutscene6", false);
                m_secondCharacterAnimator.SetBool("cutscene6",false);
                break;
        }
    }
}
