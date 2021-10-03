using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionView : MonoBehaviour
{

    public Image[] Images;
    public GameObject Unstable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateConnection(int count)
    {
        for (int i = 0; i < Images.Length; i++)
        {
            Images[i].enabled = false;
        }
        for (int i = 0; i < count+1; i++)
        {
            Images[i].enabled = true;
        }

        Unstable.SetActive(count < 2);
    }
}
