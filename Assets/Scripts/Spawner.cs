using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{

    public MoveForward ObjectToSpawn;
    public Vector3 Direction;

    public float SpawnTime;
    public float SpawnTimeDelta;
    public float DestrTime;

    private float timer;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                var obj = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
                obj.Direction = Direction;
                var rndRot = Random.Range(0,360);
                var rndTimeNextAddition = Random.Range(0,SpawnTimeDelta);
                obj.transform.Rotate(new Vector3(0,rndRot,0));
                timer = SpawnTime + rndTimeNextAddition;
                Destroy(obj.gameObject,DestrTime);
            }
        }
    }
}
