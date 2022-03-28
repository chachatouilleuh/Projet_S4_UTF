using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{

    void Start()
    {

        PlayerPrefs.SetInt("lang", 0);
        PlayerPrefs.SetInt("sub", 0);

        //Debug.Log(PlayerPrefs.GetInt("lang"));
        //Debug.Log(PlayerPrefs.GetInt("sub"));
    }

}
