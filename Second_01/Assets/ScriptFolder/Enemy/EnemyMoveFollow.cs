using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveFollow : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    public Transform[] Waypoint;  //�����ǰ� �迭
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

        //���� ������ �Ÿ��� ��������Ʈ�� �Ÿ� ���

        if (dist1 > 1.0f)
        {
            nav.SetDestination(Waypoint[i].position);  //�ش������ǰ����� �̵�

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
            i++; //���������� ������ �̵��ϱ� ���� ������
            if(i>=Waypoint.Length) //��üũ�Ⱑ 3�ε� i++�� 4�� �ɰ�� �� �����ϴ°��� ��������
            {//i = 0���� �ʱ�ȭ 
                i = 0;
                nav.SetDestination(Waypoint[i].position);
            }

        }
    }
}
