using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    float time=5;
    float speed=1;
    public float timeMax=5;
    public float distMax=200;
    // Start is called before the first frame update
    void Start()
    {
        time=timeMax;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckLose();
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

    void CheckLose() {
        if (Vector3.Distance(transform.position,new Vector3(0,0,0))>distMax) SceneManager.LoadScene(0);
    }
    

    
}
