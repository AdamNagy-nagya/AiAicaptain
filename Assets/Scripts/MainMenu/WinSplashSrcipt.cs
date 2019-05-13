using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSplashSrcipt : MonoBehaviour
{

    public GameObject splash;


    void Start()
    {
        splash = GetComponent<GameObject>();
    }


    public void showScreen(bool show) {

        splash.SetActive(show);
    }
}
