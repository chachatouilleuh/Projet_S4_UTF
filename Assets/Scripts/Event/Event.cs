using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEvent", menuName = "Event/Triggered")]
public class Event : ScriptableObject
{
    public delegate void TriggeredDelegate(List<KeyType> p_playeKey);

    public event TriggeredDelegate onTriggered;

    public delegate void TriggerDel();

    public event TriggerDel onTrigger;

    public void Raise(List<KeyType> PlayerKey)
    {
        onTriggered?.Invoke(PlayerKey);
    }

    public void Chouck()
    {
        onTrigger?.Invoke();
    }

    

}
