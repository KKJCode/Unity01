using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 30f);
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            if (other.GetComponent<BossHealth>())
                other.GetComponent<BossHealth>().Damage(500);
            if (other.GetComponent<TargetHealth>())
                other.GetComponent<TargetHealth>().Damage(500);
            if (other.GetComponent<EnemyHealth>())
                other.GetComponent<EnemyHealth>().Damage(500);
        }
    }
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        Destroy(gameObject);
    //        if (other.gameObject.GetComponent<BossHealth>())
    //            other.gameObject.GetComponent<BossHealth>().Damage(500);
    //        if (other.gameObject.GetComponent<TargetHealth>())

    //            other.gameObject.GetComponent<TargetHealth>().Damage(500);
    //        if (other.gameObject.GetComponent<EnemyHealth>())

    //            other.gameObject.GetComponent<EnemyHealth>().Damage(500);
    //    }
    //}
}
