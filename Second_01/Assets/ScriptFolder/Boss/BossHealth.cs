using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int hp = 250;
    public RawImage imgBar;
    public void Damage(int amount)
    {
        if (hp <= 0)
        {
            return;
        }
        hp -= amount;
        imgBar.transform.localScale = new Vector3(hp / 250.0f, 1, 1);
        if (hp <= 0)
        {
            Score.Myscore += 150;
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<BossFollow>().enabled = false;

            Destroy(gameObject, 2);
            GameObject.Find("GameManager").GetComponent<MobSpawn>().count[1]--;
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
