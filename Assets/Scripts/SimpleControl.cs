using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControl : MonoBehaviour
{

    public SimpleMovement RCMovement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RCMovement.MoveForwardAction();
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            RCMovement.RotateAction(-1);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            RCMovement.RotateAction(1);
        }
    }
}
