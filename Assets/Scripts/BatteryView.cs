using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryView : MonoBehaviour
{
    
    public Image[] Images;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateBat(float capacity)
    {
        var count = 0;
        if (capacity > 0.2f) count = 1;
        if (capacity > 0.4f) count = 2;
        if (capacity > 0.6f) count = 3;
        if (capacity > 0.8f) count = 4;
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].enabled = false;
        }
        for (int i = 0; i < count; i++)
        {
            Images[i].enabled = true;
        }
    }
}
