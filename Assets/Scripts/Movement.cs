using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    float time=5;
    float speed=1;
    public float timeMax=5;
    // Start is called before the first frame update
    void Start()
    {
        time=timeMax;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        time-=Time.deltaTime;
        if (time<0) {
            Spin();
            time=timeMax;
        }
    }

    void Move()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    void Spin() {
        var rnd=Random.Range(0,360);
        transform.Rotate(new Vector3(0,rnd,0));    }

    void OnMouseDown() {
        speed++;
        Spin();
    }
    

    
}
