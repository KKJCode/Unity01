using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5;
    bool Jdown;
    bool isJump;
    Rigidbody rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Jump1()
    {
        
        if (/*Jdown && */!isJump) //bool값 앞에 !를 추가한다면 bool값이 반대로 사용됌
        {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            isJump = true;
            GetComponent<Animator>().SetTrigger("doJump");

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Jdown = Input.GetButtonDown("Jump");



        //float h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        //float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

        if (h != 0.0f || v != 0.0f)
        {
            Vector3 dir = h * Vector3.right + v * Vector3.forward;
            transform.rotation = Quaternion.LookRotation(dir);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            GetComponent<Animator>().SetBool("bMove", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("bMove", false);

        }
        
        if (CrossPlatformInputManager.GetButton("Jump")||Input.GetKeyDown("space"))
        {
            Jump1();
        }
    }
}
