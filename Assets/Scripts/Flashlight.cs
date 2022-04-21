using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool m_isOn;

    private void Start()
    {
        this.GetComponent<Light>().enabled = false;
        m_isOn = false;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;
        switch (m_isOn)
        {
            case false:
                m_isOn = true;
                this.GetComponent<Light>().enabled = true;
                break;
            case true:
                m_isOn = false;
                this.GetComponent<Light>().enabled = false;
                break;
        }
    }
}
