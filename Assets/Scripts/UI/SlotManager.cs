using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField, Tooltip("les slots à assigner")] private GameObject ProbeSlot1, ProbeSlot2, ProbeSlot3, EmptyProbeSlot1, EmptyProbeSlot2, EmptyProbeSlot3, LoreSlot1, LoreSlot2, LoreSlot3 ;

    [SerializeField, Tooltip("le nombre de sondes récupérées ")]private int m_probeCount =1;

    private void Awake()
    {
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
    }

    private void Update()
    {
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
