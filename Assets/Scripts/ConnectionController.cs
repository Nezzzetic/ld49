using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConnectionController : MonoBehaviour
{
    public GameObject[] SignalMarkers;
    public Connector[] SignalObj;
    public int SignalLevel;

    void ProcessSignal()
    {
        var signal = 0;
        foreach (var obj in SignalObj)
        {
            var res = checkConnectionToConnector(obj);
            if (res > signal)
                signal = res;
        }
        if (signal!=SignalLevel) {
            SignalLevel = signal;
            ConnectionChanged();
        }
    }
    
    private void FixedUpdate()
    {
        ProcessSignal();
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
     
}
