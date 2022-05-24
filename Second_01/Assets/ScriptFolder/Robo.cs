using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Robo : MonoBehaviour
{
    public float autodist = 1f;
    Transform player;
    NavMeshAgent nav;
    Vector3 posReturn; //���� �ʱ� ��ġ�� ����� 

    public float MaxDist = 15;
    public float MinDist = 10;

    //�Լ� ��ȣ

    void Start()
    {
        player = GameObject.Find("Player").transform;
        nav = GetComponent<NavMeshAgent>();

        posReturn = transform.position; //�����ϸ� ���� ���� ��ġ �� ����
    }

    void Update()
    {
        //�ذ��� �޾ƿ��°��� �ƴ� �� ���� �Ÿ����� ����ԡ�
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > MaxDist) //�÷��̾�� �Ÿ��� �־������� �ʱ� ������ǥ�� ���ư�
        {
            nav.SetDestination(posReturn); //NavMeshAgent�� �̿��� ������ǥ�� ���ư�

            if (Vector3.Distance(transform.position, posReturn) > autodist) //���������� �� ��ġ�� ����ؼ� �Ÿ��� 1 �̻��̸�
            {
                GetComponent<Animator>().SetBool("bmove", true); //�Ÿ��� �ֱ⶧���� �����̴� �ִϸ��̼� ����
            }
            else//1���� ���ٸ� �����Ѱ��̱⿡ �����̴� �ִϸ��̼ǿ��� Idle�� �Ѿ
            {
                GetComponent<Animator>().SetBool("bmove", false);
            }
        }
        else if (dist > MinDist)  //max�����ٴ� ������ min���ٴ� ū(�Ÿ��� �����ȿ� ������)
        {
            nav.SetDestination(player.position); //���� �ȿ� �ֱ⶧���� �÷��̾� ����
            GetComponent<Animator>().SetBool("bmove", true); //�ִϸ��̼� true�༭ ���� Ȯ���ϰ� �ϱ� ���� �ѹ� �� ���
        }
        else
        {
            nav.SetDestination(transform.position);
            GetComponent<Animator>().SetBool("bmove", false);
        }

    }
}
