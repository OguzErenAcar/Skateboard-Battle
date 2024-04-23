using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardMoveWeb : SkateboardMove
{
    // get web input 

   
    private float _horizantalInput;
    private float _verticalInput;
    new
    void Start()
    { 
      base.Start();
    SocketManager.socket.On("GetMove", response =>{
        print(response);
    }); 
    }

    // Update is called once per frame
    new 
    void Update()
    {
        base.Update();
        // float HorizontalInput=Input.GetAxis("Horizontal");
        // float ForwardInput=Input.GetAxis("Vertical");
        // SocketManager.socket.Emit("Move",HorizontalInput,ForwardInput);

    }

    
   public override void Move(){
         HorizontalInput=Input.GetAxis("Horizontal");
         ForwardInput=Input.GetAxis("Vertical"); 
       //transform.eulerAngles+=transform.eulerAngles*Time.deltaTime*HorizontalInput*rotate;
        Vector3 HorizantalVector=Vector3.up*Time.deltaTime*HorizontalInput*rotateSpeed;
        Vector3 VerticalVector=transform.forward*Time.deltaTime*ForwardInput*Speed;
       // rigidbody_.AddForce(Vector3.forward*ForwardInput*Speed); 
        transform.Rotate(HorizantalVector,Space.Self);
        transform.Translate(VerticalVector,Space.World); 

    }
}
