using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCredit : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName:"Menu");
        }
    }
}
