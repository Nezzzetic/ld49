using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWithLatency : MonoBehaviour
{
    
    public SimpleMovement RCMovement;
    public int LatencyValue;
    private List<int> moveCommands;
    private List<int> rotateCommands;

    private int movePressed;
    private int rotPressed;
    // Start is called before the first frame update
    void Awake()
    {
        moveCommands= new List<int>();
        rotateCommands= new List<int>();
        for (var i=0;i<LatencyValue;i++) {
            moveCommands.Add(0);
            rotateCommands.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movePressed = 1;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rotPressed=-1;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rotPressed=1;
        }
    }

    void ProcessInput()
    {
        addMoveActionInQ(movePressed);
        movePressed = 0;
        addRotActionInQ(rotPressed);
        rotPressed = 0;
    }
    
    void ProcessQ()
    {
        if (moveCommands.Count > 0)
            removeMoveActionInQ();
        if (rotateCommands.Count > 0)
            removeRotActionInQ();
    }

    private void FixedUpdate()
    {
        ProcessInput();
        ProcessQ();
    }

    void addMoveActionInQ(int flag)
    {
        moveCommands.Add(flag);
    }
    
    //TODO поменять на подходящий для такой очереди "лист"
    void removeMoveActionInQ()
    {
        var moveAction = moveCommands[0];
        moveCommands.RemoveAt(0);
        if (moveAction == 1)
        {
            RCMovement.MoveForwardAction();
        }
    }
    
    void addRotActionInQ(int direction)
    {
        rotateCommands.Add(direction);
    }
    
    //TODO поменять на подходящий для такой очереди "лист"
    void removeRotActionInQ()
    {
        var rotAction = rotateCommands[0];
        rotateCommands.RemoveAt(0);
        if (rotAction != 0)
        {
            RCMovement.RotateAction(rotAction);
        }
    }
}
