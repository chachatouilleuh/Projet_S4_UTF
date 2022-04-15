using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Tooltip("vitesse de déplacement")] private float m_moveSpeed;
    [SerializeField, Tooltip("vitesse de marche")] private float m_walkSpeed;
    [SerializeField, Tooltip("vitesse de course")] private float m_runSpeed;
    
    private Vector3 m_moveDirection;
    private Vector3 m_velocity;

    [SerializeField, Tooltip("Grounded or not ?")] private bool m_isGrounded;
    [SerializeField, Tooltip("distance detection sol")] private float m_groundCheckDistance;
    [SerializeField, Tooltip("layer détécté")] private LayerMask m_groundMask;
    [SerializeField, Tooltip("gravity")] private float m_gravity;

    [SerializeField, Tooltip("hauteur jump")] private float m_jumpHeight;

    [SerializeField, Tooltip("chara controller")] private CharacterController m_controller;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        m_isGrounded = Physics.CheckSphere(transform.position, m_groundCheckDistance, m_groundMask);

        if (m_isGrounded && m_velocity.y < 0)
        {
            m_velocity.y = -2f;
        }
            
        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        m_moveDirection = new Vector3(moveX, 0, moveZ);

        if (m_isGrounded)
        {
            if (m_moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (m_moveDirection == Vector3.forward && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if(m_moveDirection == Vector3.zero)
            {
                Idle();
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        m_moveDirection *= m_moveSpeed;
        m_controller.Move(m_moveDirection * Time.deltaTime);

        m_velocity.y += m_gravity * Time.deltaTime;
        m_controller.Move(m_velocity * Time.deltaTime);
    }

    private void Idle()
    {
        
    }

    private void Walk()
    {
        m_moveSpeed = m_walkSpeed;
    }

    private void Run()
    {
        m_moveSpeed = m_runSpeed;
    }

    private void Jump()
    {
        m_velocity.y = Mathf.Sqrt(m_jumpHeight * -2 * m_gravity);
    }
    
}
