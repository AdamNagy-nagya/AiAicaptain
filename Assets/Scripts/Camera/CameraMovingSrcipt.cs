﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingSrcipt : MonoBehaviour
{
    private int speed = 100;
    private ISceneRouter sceneRouter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(new Vector3(0, 0, (speed/3) * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(new Vector3(0,0, -(speed / 3) * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Escape)) {
            if (sceneRouter == null) {
                sceneRouter = new SceneRouter();
            }
            sceneRouter.backToMenu();
        }

    }
}
