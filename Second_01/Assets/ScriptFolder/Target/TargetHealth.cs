using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHealth : MonoBehaviour
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
        if (hp <= 0)
        {
            //GetComponent<Animator>().SetTrigger("Death");
            Score.Myscore += 5;
            Destroy(gameObject);
            GameObject.Find("GameManager").GetComponent<MobSpawn>().count[2]--;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
