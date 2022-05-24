using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossFollow : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav; 

    void Start()
    {
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (nav.isOnNavMesh)
            nav.SetDestination(player.position);
    }
}
