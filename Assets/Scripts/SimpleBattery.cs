using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBattery : MonoBehaviour
{
    public float BatteryMax;
    public float Battery;
    public float BatterySpeed;
    public SimpleMovement SimpleMovement;
    // Start is called before the first frame update
    void Awake()
    {
        Battery = BatteryMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Battery > 0)
        {
            Battery -= BatterySpeed * Time.deltaTime;
        }

        if (Battery <= 0)
        {
            Debug.Log("Battery Off");
            SimpleMovement.enabled = false;
        }
    }
}
