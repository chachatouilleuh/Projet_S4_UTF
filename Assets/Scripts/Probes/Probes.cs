using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probes : MonoBehaviour, IProbes
{
    [SerializeField, Tooltip("Recup les données de la sonde")]
    private ProbesType m_probes;

    public bool GetProbes(out ProbesType o_probes)
    {
        bool probesFound = false;
        //loot de la probes
        if (m_probes == null)
        {
            Debug.Log("Pas de sonde");
        }
        else
        {
            probesFound = true;
            Debug.Log($"Tu as récupéré {m_probes}");
        }
        o_probes = m_probes;
        return probesFound;
    }
}
