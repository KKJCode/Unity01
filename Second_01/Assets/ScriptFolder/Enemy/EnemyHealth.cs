using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int hp = 100;
    public RawImage imgBar;

    public void Damage(int amount)
    {
        if (hp <= 0)
        {
            return;
        }
        hp -= amount;
        imgBar.transform.localScale = new Vector3(hp / 100.0f, 1, 1);
        if(hp<=0)
        {
            Score.Myscore += 10;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<EnemyMoveFollow>().enabled = false;

            Destroy(gameObject, 2);
            GameObject.Find("GameManager").GetComponent<MobSpawn>().count[0]--;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
