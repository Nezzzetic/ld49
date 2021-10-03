using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControl : MonoBehaviour
{

    public SignalController SignalController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int move = 0;
    private int rot = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            move = 1;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rot = -1;
        }
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rot = 1;
        }
    }

    private void FixedUpdate()
    {
        SignalController.ReceiveSignal(SignalType.move,move);
            move = 0;
            SignalController.ReceiveSignal(SignalType.rotation,rot);
            rot = 0;
    }
}
