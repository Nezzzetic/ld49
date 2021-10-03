using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public static CameraSwitch SwitchActive;
    public Transform CameraPos;
    public Camera MCamera;
    private void OnTriggerEnter(Collider other)
    {
        MCamera.transform.position = CameraPos.transform.position;
        SwitchActive = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
