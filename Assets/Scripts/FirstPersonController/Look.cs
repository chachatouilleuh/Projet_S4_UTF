using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField, Tooltip("transform du controller")] Transform m_character;
    [SerializeField, Tooltip("sensibilité de la cam")] private float m_sensitivity;
    [SerializeField, Tooltip("smooth des movements de la cam")] private float m_smoothing;

    [SerializeField, Tooltip("le hud est actif ou non")]
    public static bool m_isOption;
    [SerializeField, Tooltip("le canvas du pointeur à assigner")] private GameObject Pointeur;

    Vector2 velocity;
    Vector2 frameVelocity;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        m_character = GetComponentInParent<Movement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get smooth velocity.
        if (!m_isOption)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * m_sensitivity);
            frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / m_smoothing);
            velocity += frameVelocity;
            velocity.y = Mathf.Clamp(velocity.y, -90, 90);
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            m_character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }
        else
        {
            //velocity.y = velocity.y;
            transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
            m_character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
        }


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!m_isOption)
            {
                m_isOption = true;
                Cursor.lockState = CursorLockMode.Confined;
                DeactivatePointeur();
            }
            else
            {
                m_isOption = false;
                Cursor.lockState = CursorLockMode.Locked;
                DeactivatePointeur();
            }
        }
    }

    public void DeactivatePointeur()
    {
        if (!m_isOption)
        {
            Pointeur.SetActive(true);
        }
        else
        {
            Pointeur.SetActive(false);
        }
    }
}

  
  

