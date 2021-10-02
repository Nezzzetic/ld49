
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum SignalType
{
    move,
    rotation
}

public class Signal
{
    public SignalType SignalType;
    public int Value;
    public int Counter;
    public int Timer;
}
public class SignalController : MonoBehaviour
{
    private ConnectionController ConnectionController;
    private CommandProcessor CommandProcessor;
    private List<Signal> Signals;
    public int[] LatencyValues;
    public int[] LossValues;
    int Counter;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ProcessSignals()
    {
        var ready=new List<Signal>();
        foreach (var obj in Signals)
        {
            obj.Timer--;
            if (obj.Timer <= 0)
                ready.Add(obj);
        }
        
        foreach (var obj in ready)
        {
            Signals.Remove(obj);
            removeSignalsOfType(obj.SignalType,obj.Counter);
            ProcessSignal(obj);
        }
        
    }

    void removeSignalsOfType(SignalType type, int counter)
    {
        var ready=new List<Signal>();
        foreach (var obj in Signals)
        {
            if (obj.SignalType==type && obj.Counter<obj.Counter)
                ready.Add(obj);
        }
        foreach (var obj in ready)
            Signals.Remove(obj);
        
    }

    void ProcessSignal(Signal signal)
    {
        if (signal.SignalType == SignalType.move)
        {
            CommandProcessor.ProcessMoveCommand(signal.Value);
        }
        if (signal.SignalType==SignalType.rotation)
        {
            CommandProcessor.ProcessRotCommand(signal.Value);
        }
    }
    

    private void FixedUpdate()
    {
        ProcessSignals();
    }
    
    public void ReceiveSignal(SignalType type, int value)
    {
        int rnd = Random.Range(0, 100);
        if (rnd < LossValues[ConnectionController.SignalLevel])
            AddSignal(type, value);
    }

    public void AddSignal(SignalType type, int value)
    {
        var signal = new Signal();
        signal.SignalType = type;
        signal.Value = value;
        signal.Counter = Counter;
        Counter++;
        signal.Timer = LatencyValues[ConnectionController.SignalLevel];
        Signals.Add(signal);
    }
    
    
}
