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
    public Vector3 grav = new Vector3(0,-9.81f,0);
    public CharacterController CC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CC.Move(grav*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        MoveAction();
        RotateAction();
        GravityAction();
    }
    
    public void SetMoveState(int state)
    {
        moveValue = state;
    }
    
    public void SetRotState(int state)
    {
        rotationValue = state;
    }
    
    public void MoveAction()
    {
        CC.Move(transform.forward * moveSpeed * moveValue);
    }
    
    //TODO плавный поворот
    public void RotateAction()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * rotationValue, 0));
    }
    
    public void GravityAction()
    {
        CC.Move(grav*0.04f);
    }
}
