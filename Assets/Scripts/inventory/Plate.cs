using System;
using UnityEngine;

public class Plate : MonoBehaviour, IPlate
{
    [SerializeField, Tooltip("recup KeyType")]
    private KeyType m_plates;

    public bool ActivePlate(out KeyType o_plates)
    {
        bool plateActive = false;

        if (m_plates == null)
        {
            Debug.Log("plate pas active");
        }
        else
        {
            plateActive = true;
            Debug.Log($"Tu as activé {m_plates}");
        }

        o_plates = m_plates;
        return plateActive;
    }
}
