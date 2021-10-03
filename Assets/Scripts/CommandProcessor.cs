using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private int moveCommand;
    private int rotCommand;
    public SimpleMovement Movement;
    public SimpleBattery SimpleBattery;
    public Transform FXNest;
    public GameObject FX;
    public float FXtimeout;

    public void ProcessMoveCommand(int command)
    {
        if (SimpleBattery.Battery<0) return;
        moveCommand = command;
        Movement.SetMoveState(command);
        //CreateFx();
    }
    
    public void ProcessRotCommand(int command)
    {
        if (SimpleBattery.Battery<0) return;
        rotCommand = command;
        Movement.SetRotState(command);
        //CreateFx();
    }

    void CreateFx()
    {
        if (FXtimeout>0) return;
        FX.SetActive(true);
        FXtimeout=0.5f;
    }


    
}
