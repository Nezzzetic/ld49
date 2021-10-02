using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private int moveCommand;
    private int rotCommand;
    public SimpleMovement Movement;
    public SimpleBattery SimpleBattery;

    public void ProcessMoveCommand(int command)
    {
        if (SimpleBattery.Battery<0) return;
        moveCommand = command;
        Movement.SetMoveState(command);
    }
    
    public void ProcessRotCommand(int command)
    {
        if (SimpleBattery.Battery<0) return;
        rotCommand = command;
        Movement.SetRotState(command);
    }
    
}
