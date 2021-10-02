using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPosition : MonoBehaviour
{
    public Transform SyncObj;

    public Vector3 OffsetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = SyncObj.transform.position + OffsetPosition;
        transform.rotation = SyncObj.transform.rotation;
    }
}
