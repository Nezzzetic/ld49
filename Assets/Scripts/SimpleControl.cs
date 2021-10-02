using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControl : MonoBehaviour
{

    public SignalController SignalController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            SignalController.ReceiveSignal(SignalType.move,1);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            SignalController.ReceiveSignal(SignalType.rotation,-1);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            SignalController.ReceiveSignal(SignalType.rotation,1);
        }
    }
}
