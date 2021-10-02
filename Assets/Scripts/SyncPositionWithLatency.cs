using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPositionWithLatency : MonoBehaviour
{
    public Transform SyncObj;
    public int LatencyValue;
    private List<Vector3> syncPosData;
    private List<Quaternion> syncRotData;

    public Vector3 OffsetPosition;
    // Start is called before the first frame update
    void Awake()
    {
        syncPosData= new List<Vector3>();
        syncRotData= new List<Quaternion>();
        for (var i=0;i<LatencyValue;i++) {
            syncPosData.Add(new Vector3(0,0,0));
            syncRotData.Add(Quaternion.identity);
        }
    }

    // Update is called once per frame


    private void FixedUpdate()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        addPosInQ(SyncObj.transform.position);
        addRotActionInQ(SyncObj.transform.rotation);
    }
    
    void ProcessQ()
    {
        if (syncPosData.Count > 0)
            removePosInQ();
        if (syncRotData.Count > 0)
            removeRotActionInQ();
    }

    void addPosInQ(Vector3 pos)
    {
        syncPosData.Add(pos);
    }
    
    //TODO поменять на подходящий для такой очереди "лист"
    void removePosInQ()
    {
        var moveAction = moveCommands[0];
        moveCommands.RemoveAt(0);
        transform.position = moveAction + OffsetPosition;
    }
    
    void addRotActionInQ(Quaternion q)
    {
        syncRotData.Add(q);
    }
    
    //TODO поменять на подходящий для такой очереди "лист"
    void removeRotActionInQ()
    {
        var rotAction = syncRotData[0];
        syncRotData.RemoveAt(0);
        transform.rotation = rotAction;
        
    }
}
