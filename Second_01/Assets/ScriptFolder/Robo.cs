using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robo : MonoBehaviour
{
    public float autodist = 1f;
    Transform player;
    NavMeshAgent nav;
    Vector3 posReturn; //펫의 초기 위치값 저장용 

    public float MaxDist = 15;
    public float MinDist = 10;

    //함수 괄호

    void Start()
    {
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        posReturn = transform.position; //시작하며 펫이 나온 위치 값 저장
    }

    void Update()
    {
        //※값을 받아오는것이 아닌 두 지점 거리값을 계산함※
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > MaxDist) //플레이어와 거리가 멀어졌으니 초기 생성좌표로 돌아감
        {
            nav.SetDestination(posReturn); //NavMeshAgent를 이용해 시작좌표로 돌아감

            if (Vector3.Distance(transform.position, posReturn) > autodist) //시작지점과 내 위치를 계산해서 거리가 1 이상이면
            {
                GetComponent<Animator>().SetBool("bmove", true); //거리가 멀기때문에 움직이는 애니메이션 동작
            }
            else//1보다 적다면 도착한것이기에 움직이는 애니메이션에서 Idle로 넘어감
            {
                GetComponent<Animator>().SetBool("bmove", false);
            }
        }
        else if (dist > MinDist)  //max값보다는 적지만 min보다는 큰(거리가 범위안에 있을때)
        {
            nav.SetDestination(player.position); //범위 안에 있기때문에 플레이어 따라감
            GetComponent<Animator>().SetBool("bmove", true); //애니메이션 true줘서 실행 확실하게 하기 위해 한번 더 사용
        }
        else
        {
            nav.SetDestination(transform.position);
            GetComponent<Animator>().SetBool("bmove", false);
        }

    }
}
