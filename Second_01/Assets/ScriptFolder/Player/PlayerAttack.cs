using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerAttack : MonoBehaviour
{
    float timer;
    public LineRenderer[] line;
    Transform shootPoint;
    public GameObject APB;
    public AudioClip clipLaser1;
    public AudioClip clipLaser2;
    public AudioClip clipAP;


    void Start()
    {
        line[0] = GetComponent<LineRenderer>();
        line[1] = this.transform.Find("SubShoot").GetComponent<LineRenderer>();
        
        shootPoint = transform.Find("ShootPoint");
        
    }
    void Shoot()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable")))
        {
            EnemyHealth e = hit.collider.GetComponent<EnemyHealth>();
            if (e != null)
            {
                e.Damage(50);
                
            }
            line[0].enabled = true;
            line[0].SetPosition(0, shootPoint.position);
            line[0].SetPosition(1, hit.point);
        }
        else
        {
            line[0].enabled = true;
            line[0].SetPosition(0, shootPoint.position);
            line[0].SetPosition(1, shootPoint.position + ray.direction * 100);
        }
    }

    void Shoot1()
    {
        Debug.Log("FIRE");
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable")))
        {
            TargetHealth e = hit.collider.GetComponent<TargetHealth>();
            if (e != null)
            {
                e.Damage(50);
                
            }
            line[0].enabled = true;
            line[0].SetPosition(0, shootPoint.position);
            line[0].SetPosition(1, hit.point);
        }
        else
        {
            line[0].enabled = true;
            line[0].SetPosition(0, shootPoint.position);
            line[0].SetPosition(1, shootPoint.position + ray.direction * 100);
        }
    }
    void Shoot2()
    {
        Ray ray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Shootable")))
        {
            BossHealth e = hit.collider.GetComponent<BossHealth>();
            if (e != null)
            {
                e.Damage(50);
            }
            line[0].enabled = true;
            line[0].SetPosition(0, shootPoint.position);
            line[0].SetPosition(1, hit.point);
        }
        else
        {
            line[0].enabled = true;
            line[0].SetPosition(0, shootPoint.position);
            line[0].SetPosition(1, shootPoint.position + ray.direction * 100);
        }
    }

    void SubShoot1()
    {
        Ray subray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(subray, out hit, 150, LayerMask.GetMask("Shootable")))
        {
            TargetHealth e = hit.collider.GetComponent<TargetHealth>();
            if (e != null)
            {
                e.Damage(100);
            }
            line[1].enabled = true;
            line[1].SetPosition(0, shootPoint.position);
            line[1].SetPosition(1, hit.point);
        }
        else
        {
            line[1].enabled = true;
            line[1].SetPosition(0, shootPoint.position);
            line[1].SetPosition(1, shootPoint.position + subray.direction * 150);
        }
    }
    void SubShoot2()
    {
        Ray subray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(subray, out hit, 150, LayerMask.GetMask("Shootable")))
        {
            EnemyHealth e = hit.collider.GetComponent<EnemyHealth>();
            if (e != null)
            {
                e.Damage(100);
            }
            line[1].enabled = true;
            line[1].SetPosition(0, shootPoint.position);
            line[1].SetPosition(1, hit.point);
        }
        else
        {
            line[1].enabled = true;
            line[1].SetPosition(0, shootPoint.position);
            line[1].SetPosition(1, shootPoint.position + subray.direction * 150);
        }
    }
    void SubShoot3()
    {
        Ray subray = new Ray(shootPoint.position, shootPoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(subray, out hit, 150, LayerMask.GetMask("Shootable")))
        {
            BossHealth e = hit.collider.GetComponent<BossHealth>();
            if (e != null)
            {
                e.Damage(100);
            }
            line[1].enabled = true;
            line[1].SetPosition(0, shootPoint.position);
            line[1].SetPosition(1, hit.point);
        }
        else
        {
            line[1].enabled = true;
            line[1].SetPosition(0, shootPoint.position);
            line[1].SetPosition(1, shootPoint.position + subray.direction * 150);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (CrossPlatformInputManager.GetButton("Fire1") && timer >= 0.9f)
        {
            timer = 0;
            Shoot();
            Shoot1();
            Shoot2();
            GetComponent<Animator>().SetBool("bShoot", true);
            GetComponent<Animator>().SetBool("bWalkShoot", true);
            GetComponent<AudioSource>().PlayOneShot(clipLaser1);

        }
        else
        {
            GetComponent<Animator>().SetBool("bShoot", false);
            GetComponent<Animator>().SetBool("bWalkShoot", false);
        }
        if (CrossPlatformInputManager.GetButton("Fire2") && timer >= 1.5f)
        {
            timer = 0;
            SubShoot1();
            SubShoot2();
            SubShoot3();
            GetComponent<Animator>().SetBool("bShoot", true);
            GetComponent<Animator>().SetBool("bWalkShoot", true);
            GetComponent<AudioSource>().PlayOneShot(clipLaser2);
        }
        else
        {
            GetComponent<Animator>().SetBool("bShoot", false);
            GetComponent<Animator>().SetBool("bWalkShoot", false);
        }
        if (timer > 0.05f)
        {
            line[0].enabled = false;
            line[1].enabled = false;
        }
        if (CrossPlatformInputManager.GetButton("Fire3") && timer >= 2.5f)
        {
            timer = 0;
            Instantiate(APB, shootPoint.transform.position, (transform.rotation * Quaternion.Euler(-90, 0, 0)));
            GetComponent<AudioSource>().PlayOneShot(clipAP);
        }
  
       
    }
} 

