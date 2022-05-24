using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    bool bDamage;  //������ �ް� �ȹް� �������ִ� ����
    public RawImage imgDamage; //������ �Ծ����� �����ִ� ū �̹��� //���İ� 0���� �ʼ� ���ϸ� ������
    public RawImage imgBar; //ü�¹�
    public Slider sliderHP;

    Vector3 posRespawn; //�÷��̾ ó���� �����Ȱ��� ��ǥ�� �����

    public void Damage(int amount)//EnemyAttack���� ������ ������ �Լ�
    {
        if(hp<=0) //�÷��̾�hp�� 0�ϰ�� ����(�ƹ��͵� ����X)
        {
            return;
        }

        hp -= amount; //������ �Լ��� ���� hp�� ��� �����

        bDamage = true; //������ �Լ� ����� true
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1); //bDamage�� true�� �Ǹ�
        //ü�¹��� �������� �����ϸ� �װ� hp/100���� �����ϰ� �������� 1,1�� ����

        sliderHP.value = hp; //�����̴� �������� hp �־���


        if(hp<=0) //DeathƮ���� �������� �ִϸ����Ϳ��� �״� �ִϸ��̼� ����
            //�����ڿ� �����Ӱ� ������ ���� ���ϰ� ��
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<PlayerMove>().enabled = false;

            Invoke("Respawn", 2);  //���� ����� Invokerepeat�� ����ó�� �ݺ�����
            //invoke�� �ѹ����� ������ update���� �����Ͽ� ���������� respawn�Լ� �����Ͽ�
            //������
        }
    }


    void Start()
    {
        posRespawn = transform.position; //�÷��̾ ó���� �����Ȱ��� ��ǥ�� ����
    }

    public void Respawn()
    {
        hp = 100; //hp�� 0���� �װ� �ٽ� �������ϱ⿡ hp 100�� �ٽ� ��
        transform.position = posRespawn; //ó�� ������ ��ǥ������ ������
        GetComponent<Animator>().SetTrigger("Respawn"); 
        GetComponent<PlayerAttack>().enabled = true;//�Ʊ� �׾ ������ ��ũ��Ʈ �ٽ� ����
        GetComponent<PlayerMove>().enabled = true;
        imgBar.transform.localScale = new Vector3(1, 1, 1);  //�������� ������� ü�¹ٵ� �ʱ�ȭ
        sliderHP.value = hp;  //�����̴��� �������� hp���� �־���


    }

    void Update()
    {
        if(bDamage)
        {
            imgDamage.color = new Color(0, 0.8f, 1, 1);
        }
        else
        {
            imgDamage.color = Color.Lerp(imgDamage.color, Color.clear, 5 * Time.deltaTime);
        }
        bDamage = false;
    }
}
