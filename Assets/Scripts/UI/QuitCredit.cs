using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCredit : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            PlayerPrefs.DeleteAll();
            UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Menu");
        }
    }
}
