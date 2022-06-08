using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
	[SerializeField] private LayerMask m_playerLayer;
	
	[SerializeField] private Animator m_animator;
	
	private IEnumerator  OnTriggerEnter(Collider other){
		if((m_playerLayer.value & (1 << other.gameObject.layer)) > 0)
		{
			yield return new WaitForSeconds(2);
			m_animator.SetBool("isOpen", true);
		}
	}
}