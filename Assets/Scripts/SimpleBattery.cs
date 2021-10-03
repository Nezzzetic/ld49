using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBattery : MonoBehaviour
{
    public float BatteryMax;
    public float Battery;
    public float BatterySpeed;
    public bool BatteryEnd=false;
    public GameObject LoseScreen;
    public BatteryView BatteryView;
    // Start is called before the first frame update
    void Awake()
    {
        Battery = BatteryMax;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        processBatteryLossFromTime();
        if (!BatteryEnd) checkBatteryEnd();
    }

    void processBatteryLossFromTime()
    {
        if (!BatteryEnd)
        {
            Battery -= BatterySpeed;
            BatteryView.UpdateBat(Battery/BatteryMax);
        }

    }
    
    void checkBatteryEnd()
    {
        if (Battery < 0)
        {
            BatteryEnd = true;
            LoseScreen.SetActive(true);
        }
    }
    
}
