using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public GameObject[] prefab;
    public float time;
    public Transform[] point;

    public int[] max;
    public int[] count;

    void Create()
    {
        if(count[0]>= max[0])
        {
            return;
        }

        count[0]++;
        int i = Random.Range(0, 2);
        Instantiate(prefab[0], point[i]);
    }    
    void BossCreate()
    {
        if(count[1]>= max[1])
        {
            return;
        }

        count[1]++;
        Instantiate(prefab[1], point[2]);
    }
    void TargetCreate()
    {
        if(count[2]>= max[2])
        {
            return;
        }

        count[2]++;
        int i = Random.Range(3, 9);
        Instantiate(prefab[2], point[i]);
    }

    void Start()
    {
        InvokeRepeating("Create", time*2, time * 2);  //2
        InvokeRepeating("BossCreate", time * 25, time * 25);  //25
        InvokeRepeating("TargetCreate", time, time);  
    }



    void Update()
    {
        
    }
}
