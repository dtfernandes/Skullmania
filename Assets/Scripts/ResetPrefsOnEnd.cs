using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefsOnEnd : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
    private void OnDisable()
    {
        PlayerPrefs.DeleteAll();
    }
}
