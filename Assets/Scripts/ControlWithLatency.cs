using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWithLatency : MonoBehaviour
{
    public Transform[] SignalObj;
    public float[] SignalDistances;
    public int[] LatencyValues;
    public int SignalLevel;
    public SimpleMovement RCMovement;
    public int LatencyValue;
    public int LatencyMax;
    
    private List<int> moveCommands;
    private List<int> rotateCommands;
    private int lastMoveCommand;
    private int lastRotCommand;

    private int movePressed;
    private int rotPressed;
    // Start is called before the first frame update
    void Awake()
    {
        moveCommands= new List<int>();
        rotateCommands= new List<int>();
        for (var i=0;i<LatencyMax;i++) {
            moveCommands.Add(10);
            rotateCommands.Add(10);
        }
        changeLatency();
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
    
    void ProcessSignal()
    {
        var signal = 5;
        foreach (var obj in SignalObj)
        {
            if (Vector3.Distance(obj.position, transform.position)<SignalDistances[4] && signal>5)
            {
                signal = 5;
            }
            if (Vector3.Distance(obj.position, transform.position)<SignalDistances[3] && signal>4)
            {
                signal = 4;
            }
            if (Vector3.Distance(obj.position, transform.position)<SignalDistances[2] && signal>3)
            {
                signal = 3;
            }
            if (Vector3.Distance(obj.position, transform.position)<SignalDistances[1] && signal>2)
            {
                signal = 2;
            }
            if (Vector3.Distance(obj.position, transform.position)<SignalDistances[0] && signal>1)
            {
                signal = 1;
            }
        }
        if (signal!=SignalLevel) {
            SignalLevel = signal;
            changeLatency();
        }
    }
    
    void changeLatency()
    {
        switch (SignalLevel)
        {
            case 1:
                LatencyValue = LatencyValues[0];
                break;
            case 2:
                LatencyValue = LatencyValues[1];
                break;
            case 3:
                LatencyValue = LatencyValues[2];
                break;
            case 4:
                LatencyValue = LatencyValues[3];
                break;
            case 5:
                LatencyValue = LatencyValues[4];
                break;
        }
        Debug.Log("changeLatency");
        for (int i = LatencyValue+1; i < LatencyMax; i++)
        {
            moveCommands[i] = 10;
            rotateCommands[i] = 10;
        }
    }

    private void FixedUpdate()
    {
        ProcessInput();
        ProcessQ();
        ProcessSignal();
    }

    void addMoveActionInQ(int flag)
    {
        
        moveCommands[LatencyValue] = flag;
    }
    
    
    
    //TODO поменять на подходящий для такой очереди "лист"
    void removeMoveActionInQ()
    {
        var moveAction = moveCommands[0];
        moveCommands.RemoveAt(0);
        moveCommands.Add(10);

        if (moveAction == 10)
        {
            if (lastMoveCommand == 1)
            {
                RCMovement.MoveForwardAction(); 
                return;
            }
        }
        else
            lastMoveCommand = moveAction;
        if (moveAction == 1)
        {
            RCMovement.MoveForwardAction();
        }
    }
    
    void addRotActionInQ(int direction)
    {
        rotateCommands[LatencyValue] = direction;
    }
    
    //TODO поменять на подходящий для такой очереди "лист"
    void removeRotActionInQ()
    {
        Debug.Log(rotateCommands[0]+" "+rotateCommands[1]+" "+rotateCommands[2]+" "+rotateCommands[3]+" "+rotateCommands[4]);
        var rotAction = rotateCommands[0];
        rotateCommands.RemoveAt(0);
        rotateCommands.Add(10);
        
        if (rotAction == 10)
        {
            if (lastRotCommand == 1 || lastRotCommand==-1)
            {
                RCMovement.RotateAction(lastRotCommand);
                return;
            }
        }
        else
            lastRotCommand = rotAction;
        if (rotAction == 1 || rotAction==-1)
        {
            RCMovement.RotateAction(rotAction);
        }
    }
}
