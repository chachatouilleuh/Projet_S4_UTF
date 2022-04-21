using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField, Tooltip("les slots probes à assigner")] private GameObject ProbeSlot1, ProbeSlot2, ProbeSlot3, EmptyProbeSlot1, EmptyProbeSlot2, EmptyProbeSlot3, LoreSlot1, LoreSlot2, LoreSlot3 ;
    [SerializeField, Tooltip("les slots probes à assigner")] private GameObject RecordSlot1, RecordSlot2, RecordSlot3, RecordSlot4, RecordSlot5, RecordSlot6, EmptyRecordSlot1, EmptyRecordSlot2, EmptyRecordSlot3, EmptyRecordSlot4, EmptyRecordSlot5, EmptyRecordSlot6;

    [SerializeField, Tooltip("le nombre de sondes récupérées ")] private int m_probeCount;
    [SerializeField, Tooltip("le nombre de records récupérés ")] private int m_recordCount;

    private void Awake()
    {
        // je get mon nombre de sondes et records récupérés
        m_probeCount = PlayerPrefs.GetInt("probeCount");
        m_recordCount = PlayerPrefs.GetInt("recordCount");

        // je set au démarrage les conditions d'affichage en fontion du nombre de sondes récupérées
        switch (m_probeCount)
        {
            case 0:
                EmptyProbeSlot1.SetActive(true);
                EmptyProbeSlot2.SetActive(true);
                EmptyProbeSlot3.SetActive(true);
                break;
            
            case 1:
                OpenLore1();
                EmptyProbeSlot2.SetActive(true);
                EmptyProbeSlot3.SetActive(true);
                break;
            
            case 2:
                OpenLore1();
                ProbeSlot2.SetActive(true);
                EmptyProbeSlot3.SetActive(true);
                break;
            
            case 3:
                OpenLore1();
                ProbeSlot2.SetActive(true);
                ProbeSlot3.SetActive(true);
                break;
        }

        // je set au démarrage les conditions d'affichage en fontion du nombre de records récupérés
        switch (m_recordCount)
        {
            case 0:
                EmptyRecordSlot1.SetActive(true);
                EmptyRecordSlot2.SetActive(true);
                EmptyRecordSlot3.SetActive(true);
                EmptyRecordSlot4.SetActive(true);
                EmptyRecordSlot5.SetActive(true);
                EmptyRecordSlot6.SetActive(true);
                break;

            case 1:
                RecordSlot1.SetActive(true);
                EmptyRecordSlot2.SetActive(true);
                EmptyRecordSlot3.SetActive(true);
                EmptyRecordSlot4.SetActive(true);
                EmptyRecordSlot5.SetActive(true);
                EmptyRecordSlot6.SetActive(true);
                break;

            case 2:
                RecordSlot1.SetActive(true);
                RecordSlot2.SetActive(true);
                EmptyRecordSlot3.SetActive(true);
                EmptyRecordSlot4.SetActive(true);
                EmptyRecordSlot5.SetActive(true);
                EmptyRecordSlot6.SetActive(true);
                break;

            case 3:
                RecordSlot1.SetActive(true);
                RecordSlot2.SetActive(true);
                RecordSlot3.SetActive(true);
                EmptyRecordSlot4.SetActive(true);
                EmptyRecordSlot5.SetActive(true);
                EmptyRecordSlot6.SetActive(true);
                break;
            case 4:
                RecordSlot1.SetActive(true);
                RecordSlot2.SetActive(true);
                RecordSlot3.SetActive(true);
                RecordSlot4.SetActive(true);
                EmptyRecordSlot5.SetActive(true);
                EmptyRecordSlot6.SetActive(true);
                break;
            case 5:
                RecordSlot1.SetActive(true);
                RecordSlot2.SetActive(true);
                RecordSlot3.SetActive(true);
                RecordSlot4.SetActive(true);
                RecordSlot5.SetActive(true);
                EmptyRecordSlot6.SetActive(true);
                break;
            case 6:
                RecordSlot1.SetActive(true);
                RecordSlot2.SetActive(true);
                RecordSlot3.SetActive(true);
                RecordSlot4.SetActive(true);
                RecordSlot5.SetActive(true);
                RecordSlot6.SetActive(true);
                break;
        }
    }

    private void Update()
    {
        // Si je récupère une sonde, mon affichage s'actualise
        switch (m_probeCount)
        {
            case 1:
                ProbeSlot1.SetActive(true);
                EmptyProbeSlot1.SetActive(false);
                break;
            
            case 2:
                ProbeSlot2.SetActive(true);
                EmptyProbeSlot2.SetActive(false);
                break;
            
            case 3:
                ProbeSlot3.SetActive(true);
                EmptyProbeSlot3.SetActive(false);
                break;
        }

        // Si je récupère un record, mon affichage s'actualise
        switch (m_recordCount)
        {
            case 1:
                RecordSlot1.SetActive(true);
                EmptyRecordSlot1.SetActive(false);
                break;

            case 2:
                RecordSlot2.SetActive(true);
                EmptyRecordSlot2.SetActive(false);
                break;

            case 3:
                RecordSlot3.SetActive(true);
                EmptyRecordSlot3.SetActive(false);
                break;

            case 4:
                RecordSlot4.SetActive(true);
                EmptyRecordSlot4.SetActive(false);
                break;

            case 5:
                RecordSlot5.SetActive(true);
                EmptyRecordSlot5.SetActive(false);
                break;

            case 6:
                RecordSlot6.SetActive(true);
                EmptyRecordSlot6.SetActive(false);
                break;
        }
    }

    public void OpenLore1()
    {
        ProbeSlot1.SetActive(true);
        LoreSlot1.SetActive(true);
        LoreSlot2.SetActive(false);
        LoreSlot3.SetActive(false);
    }
    
    public void OpenLore2()
    {
        LoreSlot1.SetActive(false);
        LoreSlot2.SetActive(true);
        LoreSlot3.SetActive(false);
    }
    
    public void OpenLore3()
    {
        LoreSlot1.SetActive(false);
        LoreSlot2.SetActive(false);
        LoreSlot3.SetActive(true);
    }
    
}
