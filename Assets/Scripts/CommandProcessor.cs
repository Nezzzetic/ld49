using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    private int moveCommand;
    private int rotCommand;
    public SimpleMovement Movement;

    public void ProcessMoveCommand(int command)
    {
        moveCommand = command;
        Movement.SetMoveState(command);
    }
    
    public void ProcessRotCommand(int command)
    {
        rotCommand = command;
        Movement.SetRotState(command);
    }
    
}
