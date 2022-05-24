using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ontrigger");
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("oncollision");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger stay");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision stay");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision exit");
    }
}
