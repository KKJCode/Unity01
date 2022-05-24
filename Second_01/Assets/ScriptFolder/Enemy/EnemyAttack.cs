using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //OnTrigger�� OnCollider ó�� On�� �پ������� �ڵ�
    //Start�� Update�� ��� ���� ���̱� ������ �ڵ������� On�� ����
    //�׿ܿ��� �ǵ�,�������� �����

    GameObject player;
    float time;
    bool bInRange;  //boolŸ������ ���� ����
    
    void Start()
    {
        player = GameObject.Find("Player");
    }
    //isTrigger�� �ڵ��� ������ ���� ���������� �浹������ ����
    //�浹�Ѱ͵��� ��� �ϳ��� istrigger�� ������ �ڵ����� on trigger�� ȣ��� �ڵ�
    private void OnTriggerEnter(Collider other) //�ݶ��̴� Ÿ���� �Ű�����
    {//�����Ҷ� enter,�ӹ����� stay,Ż��ÿ��� exit,isTrigger�� Ų ������Ʈ�� �������� ��� �ڵ����� ȣ����
        if(other.gameObject == player)
        {
            bInRange = true; //�÷��̰� �����Ѱ��� ����\
            //true�� ��� ���� false�� ��� �Ⱥε��� ����
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            bInRange = false;
        }
    }


    void Update()
    {
        time += Time.deltaTime;
        if(time >= 0.5f && bInRange)// 0.5�ʺ��� Ŀ������ �÷��̾ ���� �ȿ� ������ ���� ���� ����
        {
            time = 0; //time�� ��� �����ϱ⿡ �ʱ�ȭ�� ������ ������� �÷��̾�� �������� ���������� ��
            //������ �ϰ� �ʱ�ȭ�� �Ͽ� ���� ���ݱ����� �����̸� �ָ� 1942�� ���潺���̺�ó�� �� �����°͵��� ������ �ֱⰡ ����
        player.GetComponent<PlayerHealth>().Damage(50); //�÷��̾ �ִ� playerHealth���� ������ �Լ� ����(50�� ������ �ο�)
        if(player.GetComponent<PlayerHealth>().hp<=0) //PlayerHealth�ȿ� �ִ� hp�� 0���� �۰ų� �������
        {
            GetComponent<Animator>().SetTrigger("PlayerDeath");
            //�÷��̾ �װ� �� �����̴� �ִϸ��̼��� �ƴ� Idle�� �Ѿ�� ����
            //PlayerDeath�� Ʈ���Ÿ� ����
        }
        }
        

        
    }
}
