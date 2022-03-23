using UnityEngine;

[CreateAssetMenu(fileName = "newEvent", menuName = "Event/Triggered")]
public class Event : ScriptableObject
{
    public delegate void TriggeredDelegate();

    public event TriggeredDelegate onTriggered;

    public void Raise()
    {
        onTriggered?.Invoke();
    }
}
