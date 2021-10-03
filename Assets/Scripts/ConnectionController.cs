using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConnectionController : MonoBehaviour
{
    public GameObject[] SignalMarkers;
    public Connector[] SignalObj;
    public Transform Antenas;
    public int LastSignalLevel;
    public int SignalLevel;
    public SignalBlocker currentBlocker;

    private void Awake()
    {
        SignalObj = Antenas.GetComponentsInChildren<Connector>();
    }

    void ProcessSignal()
    {
        var signal = 0;
        foreach (var obj in SignalObj)
        {
            var res = checkConnectionToConnector(obj);
            if (res > signal)
                signal = res;
        }

        SignalLevel = signal;
    }
    
    void ProcessSignalBlock()
    {
        if (currentBlocker == null) return;
        SignalLevel -= currentBlocker.SignalLevel;
        if (SignalLevel < 0) SignalLevel = 0;
    }

    void SignalChangeCheck()
    {
        if (SignalLevel!=LastSignalLevel) {
            LastSignalLevel = SignalLevel;
            ConnectionChanged();
        }
    }
    
    private void FixedUpdate()
    {
        ProcessSignal();
        ProcessSignalBlock();
        SignalChangeCheck();
    }

    void ConnectionChanged()
    {
        foreach (var marker in SignalMarkers)
        {
            marker.SetActive(false);
        }
        SignalMarkers[SignalLevel].SetActive(true);
    }
    
    int checkConnectionToConnector(Connector connector)
    {
        int signal = 0;
        for (int i = 0; i < connector.SignalDistances.Length; i++)
            if (Vector3.Distance(connector.transform.position, transform.position) < connector.SignalDistances[i])
                signal = connector.SignalLevels[i];
        return signal;
    }

    private void OnTriggerEnter(Collider other)
    {
        var block = other.GetComponent<SignalBlocker>();
        if (block != null)
        {
            currentBlocker = block;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var block = other.GetComponent<SignalBlocker>();
        if (block != null)
        {
            currentBlocker = null;
        }
    }
}
