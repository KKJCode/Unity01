using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //OnTrigger나 OnCollider 처럼 On이 붙어있으면 자동
    //Start나 Update의 경우 자주 쓰이기 때문에 자동이지만 On이 없음
    //그외에는 피동,수동으로 실행됨

    GameObject player;
    float time;
    bool bInRange;  //bool타입으로 범위 지정
    
    void Start()
    {
        player = GameObject.Find("Player");
    }
    //isTrigger는 자동문 센서와 같음 감지하지만 충돌하지는 않음
    //충돌한것들중 어느 하나만 istrigger가 있으면 자동으로 on trigger가 호출됨 자동
    private void OnTriggerEnter(Collider other) //콜라이더 타입의 매개변수
    {//진입할때 enter,머무를땐 stay,탈출시에는 exit,isTrigger를 킨 오브젝트와 접촉했을 경우 자동으로 호출함
        if(other.gameObject == player)
        {
            bInRange = true; //플레이가 접근한것을 감지\
            //true의 경우 접촉 false의 경우 안부딪힌 상태
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
        if(time >= 0.5f && bInRange)// 0.5초보다 커질경우와 플레이어가 범위 안에 있을때 적이 공격 실행
        {
            time = 0; //time이 계속 증가하기에 초기화를 해주지 않을경우 플레이어에게 데미지가 지속적으로 들어감
            //공격을 하고 초기화를 하여 다음 공격까지의 딜레이를 주며 1942나 디펜스웨이브처럼 적 나오는것도한 딜레이 주기가 가능
        player.GetComponent<PlayerHealth>().Damage(50); //플레이어에 있는 playerHealth에서 데미지 함수 실행(50의 데미지 부여)
        if(player.GetComponent<PlayerHealth>().hp<=0) //PlayerHealth안에 있는 hp가 0보다 작거나 같을경우
        {
            GetComponent<Animator>().SetTrigger("PlayerDeath");
            //플레이어가 죽고난 뒤 움직이는 애니메이션이 아닌 Idle로 넘어가기 위해
            //PlayerDeath에 트리거를 실행
        }
        }
        

        
    }
}
