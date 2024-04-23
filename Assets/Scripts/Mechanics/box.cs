using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
       private Rigidbody rigidbody_;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody_=transform.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float ForwardInput=Input.GetAxis("Vertical"); 
        //Vector3 VerticalVector=transform.up*Time.deltaTime*ForwardInput*20;

        rigidbody_.AddForce(transform.right*ForwardInput*20);
    }
}
