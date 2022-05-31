using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private BoxCollider onBottom;

    private void Start()
    {
        onBottom = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        onBottom.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        onBottom.enabled = true;
    }
}
