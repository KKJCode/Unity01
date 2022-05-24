using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveFollow : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    public Transform[] Waypoint;  //포지션값 배열
    int i = 0;
    public float Max = 15.0f;
    public float Min = 10.0f;


    void Start()
    {
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        float dist1 = Vector3.Distance(transform.position, Waypoint[i].position);
        float dist2 = Vector3.Distance(transform.position, player.position);

        //현재 본인의 거리와 웨이포인트의 거리 계산

        if (dist1 > 1.0f)
        {
            nav.SetDestination(Waypoint[i].position);  //해당포지션값으로 이동

            if(dist2>Max)
            {
                nav.SetDestination(Waypoint[i].position);
            }
            else if(dist2 > Min)
            {
                nav.SetDestination(player.position);
            }
            else
            {
                nav.SetDestination(Waypoint[i].position);
            }


        }
        else
        {
            i++; //다음포지션 값으로 이동하기 위한 증감값
            if(i>=Waypoint.Length) //전체크기가 3인데 i++로 4가 될경우 값 오버하는것을 막기위해
            {//i = 0으로 초기화 
                i = 0;
                nav.SetDestination(Waypoint[i].position);
            }

        }
    }
}
