using UnityEngine;

public class CameraSlowMotion : MonoBehaviour
{
    [SerializeField, Tooltip(" la nouvelle valeur de position")]
    private Vector3 m_newPosition;

    [SerializeField, Tooltip("la nouvelle valeur de rotation")]
    private Quaternion m_newRotation;
    
    [SerializeField, Tooltip(" valeur rotation min")]
    private Vector2 m_min;
    
    [SerializeField, Tooltip("valeur rotation max")]
    private Vector2 m_max;
    
    [SerializeField, Tooltip("rotation y")]
    private Vector2 m_yRotationRange;

    [SerializeField, Tooltip("vitesse"), Range(0.01f, 0.1f)]
    private float m_lerpSpeed = 0.05f;
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        m_newPosition = transform.position;
        m_newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, m_newPosition, Time.deltaTime * m_lerpSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, m_newRotation, Time.deltaTime * m_lerpSpeed);

        if (Vector3.Distance(transform.position, m_newPosition) < 1f)
        {
            GetNewPosition();
        }
    }

    private void GetNewPosition()
    {
        var m_xPos = Random.Range(m_min.x, m_max.x);
        var m_zPos = Random.Range(m_min.y, m_max.y);
        m_newRotation = Quaternion.Euler(0, Random.Range(m_yRotationRange.x, m_yRotationRange.y), 0);
        m_newPosition = new Vector3(m_xPos, 0, m_zPos);
    }
}
