using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 100;
    bool bDamage;  //데미지 받고 안받고를 구분해주는 변수
    public RawImage imgDamage; //데미지 입었을때 보여주는 큰 이미지 //알파값 0으로 필수 안하면 눈아픔
    public RawImage imgBar; //체력바
    public Slider sliderHP;

    Vector3 posRespawn; //플레이어가 처음에 생성된곳의 좌표값 저장용

    public void Damage(int amount)//EnemyAttack에서 실행할 데미지 함수
    {
        if(hp<=0) //플레이어hp가 0일경우 종료(아무것도 실행X)
        {
            return;
        }

        hp -= amount; //데미지 함수를 통해 hp를 계속 깎아줌

        bDamage = true; //데미지 함수 실행시 true
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1); //bDamage가 true가 되면
        //체력바의 스케일을 조정하며 그건 hp/100으로 실행하고 나머지는 1,1로 실행

        sliderHP.value = hp; //슬라이더 벨류값에 hp 넣어줌


        if(hp<=0) //Death트리거 실행으로 애니메이터에서 죽는 애니메이션 실행
            //죽은뒤에 움직임과 공격을 실행 못하게 함
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<PlayerMove>().enabled = false;

            Invoke("Respawn", 2);  //전에 사용한 Invokerepeat는 스폰처럼 반복실행
            //invoke는 한번실행 이지만 update에서 실행하여 죽을때마다 respawn함수 실행하여
            //리스폰
        }
    }


    void Start()
    {
        posRespawn = transform.position; //플레이어가 처음의 생성된곳의 좌표를 받음
    }

    public void Respawn()
    {
        hp = 100; //hp가 0으로 죽고 다시 리스폰하기에 hp 100을 다시 줌
        transform.position = posRespawn; //처음 생성된 자표값에서 제생성
        GetComponent<Animator>().SetTrigger("Respawn"); 
        GetComponent<PlayerAttack>().enabled = true;//아까 죽어서 꺼버린 스크립트 다시 실행
        GetComponent<PlayerMove>().enabled = true;
        imgBar.transform.localScale = new Vector3(1, 1, 1);  //리스폰이 됬을경우 체력바도 초기화
        sliderHP.value = hp;  //슬라이더에 벨류값에 hp값을 넣어줌


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
