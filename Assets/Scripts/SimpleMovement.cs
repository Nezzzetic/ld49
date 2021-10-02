using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float rotationSpeed;
    private int rotationValue;
    public float moveSpeed;
    private int moveValue;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if (rotationValue != 0)
        {
            transform.Rotate(new Vector3(0,rotationSpeed*rotationValue,0));
            rotationValue = 0;
        }
        
        if (moveValue != 0)
        {
            transform.position += transform.forward * moveSpeed;
            moveValue = 0;
        }
    }
    
    //TODO плавный газ
    public void MoveForwardAction()
    {
        moveValue = 1;
    }
    
    //TODO плавный поворот
    public void RotateAction(int direction)
    {
        rotationValue = direction;
    }
}
