using UnityEngine;

public class CountUpdate : MonoBehaviour
{
    [SerializeField, Tooltip("recup le layer qui declenche")]
    private LayerMask m_layer;

    [SerializeField, Tooltip("le gameobject est un record")]
    private bool m_isRecord;

    [SerializeField, Tooltip("le gameobject est une sonde")]
    private bool m_isProbe;
    
    [SerializeField, Tooltip("le numéro de la sonde (entre 1 et 3)")]
    private int m_probeNumber;

    [SerializeField, Tooltip("le numéro du record (entre 1 et 6)")]
    private int m_recordNumber;

    
    private void OnTriggerEnter(Collider other)
    {
        if ((m_layer.value & (1 << other.gameObject.layer)) > 0)
        {
            if (m_isProbe)
            {
                ProbeCountUpdate();
            }
            else if (m_isRecord)
            {
                RecordCountUpdate();
            }
        }
    }

    private void ProbeCountUpdate()
    {
        switch (m_probeNumber)
        {
            case 1:
                PlayerPrefs.SetInt("probeCount", 1);
                break;
            
            case 2:
                PlayerPrefs.SetInt("probeCount", 2);
                break;
            
            case 3:
                PlayerPrefs.SetInt("probeCount", 3);
                break;
        }
    }
    
    private void RecordCountUpdate()
    {
        switch (m_recordNumber)
        {
            case 1:
                PlayerPrefs.SetInt("recordCount", 1);
                break;
            
            case 2:
                PlayerPrefs.SetInt("recordCount", 2);
                break;
            
            case 3:
                PlayerPrefs.SetInt("recordCount", 3);
                break;
            
            case 4:
                PlayerPrefs.SetInt("recordCount", 4);
                break;
            
            case 5:
                PlayerPrefs.SetInt("recordCount", 5);
                break;
            
            case 6:
                PlayerPrefs.SetInt("recordCount", 6);
                break;
        }
    }
}
