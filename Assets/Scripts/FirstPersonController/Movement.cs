using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Tooltip("vitesse de déplacement")] private float m_moveSpeed;
    [SerializeField, Tooltip("vitesse de marche")] private float m_walkSpeed;
    [SerializeField, Tooltip("vitesse de course")] private float m_runSpeed;
    // [SerializeField, Tooltip("gravity")] private float m_gravity;

    private Vector3 m_moveDirection;

    [SerializeField, Tooltip("chara controller")] private CharacterController m_controller;

    private void Awake()
    {
        m_controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");

        m_moveDirection = new Vector3(0, 0, moveZ);
        m_moveDirection *= m_walkSpeed;

        m_controller.Move(m_moveDirection * Time.deltaTime);
    }
}
