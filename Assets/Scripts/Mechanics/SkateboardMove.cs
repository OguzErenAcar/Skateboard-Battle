using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using CustomTool;



public class SkateboardMove : MonoBehaviour
{   

   //private GameObject Wheels;
   [SerializeField] private float rotateSpeed;
   [SerializeField] private float Speed;
   [SerializeField] private float LimitRotateX;
   [SerializeField] private float LimitRotateZ;
   [SerializeField] private float slowdownTime=1;
   [SerializeField] private float AccelerationTime=2;


   private float _rotateSpeed;
   private float _Speed;
   private bool isSlowStop;
   private bool isAcceleration;
   private float time ;

   
   private CustomTools myTools=new CustomTools();
    void Start(){ 
      _rotateSpeed=rotateSpeed;
      _Speed=Speed;
      isAcceleration=true;
       // Wheels= transform.Find("WheelsColliders").gameObject;
      FlyingController.onMapCollisionExit+=StopRotate; 
      FlyingController.onMapCollisionEnter+=isAccelerationMoveAction; 
      
    }
    void Update()
    {
         Move();
         RotateLimited();
         if(isSlowStop)
            SlowStopMove();
         if(isAcceleration)
            StartMove();
    }

  
    private void StopRotate(){
      isSlowStopMoveAction(true);
      rotateSpeed=0;
      Vector3 angels =transform.localRotation.eulerAngles;
      Quaternion quaternion=Quaternion.Euler(angels.x,angels.y,0);
      transform.DOLocalRotateQuaternion(quaternion,0.2f);
   }
    private void StartMove(){
      isSlowStop=false;
      rotateSpeed=_rotateSpeed;
      time += Time.deltaTime;
      Speed = Mathf.Lerp(0, _Speed, time / AccelerationTime);

      if (time >= AccelerationTime)
      {
          Speed = _Speed;
          time=0;
          isAcceleration=false;
      }
   }

   private void SlowStopMove(){
            time += Time.deltaTime;
            Speed = Mathf.Lerp(Speed, 0f, time / slowdownTime);

            if (time >= slowdownTime)
            {
                Speed = 0f;
                isSlowStop = false;
                time=0;
            }
   }
   private void isSlowStopMoveAction(bool state ){
        isSlowStop=state;
   }
    private void isAccelerationMoveAction(bool state ){
        isAcceleration=state;
   }

   

    private void StopMove(){
          rotateSpeed=0;
          Speed=0;
      }
   private void Move(){
       float HorizontalInput=Input.GetAxis("Horizontal");
        float ForwardInput=Input.GetAxis("Vertical"); 
       //transform.eulerAngles+=transform.eulerAngles*Time.deltaTime*HorizontalInput*rotate;
        Vector3 HorizantalVector=Vector3.up*Time.deltaTime*HorizontalInput*rotateSpeed;
        Vector3 VerticalVector=transform.forward*Time.deltaTime*ForwardInput*Speed;
       // rigidbody_.AddForce(Vector3.forward*ForwardInput*Speed); 
        transform.Rotate(HorizantalVector,Space.Self);
        transform.Translate(VerticalVector,Space.World);
    }
   


    private void RotateLimited(){
      Vector3 SkateboardAngles= transform.localRotation.eulerAngles;

       SkateboardAngles.x=(SkateboardAngles.x>180) ? SkateboardAngles.x-360:SkateboardAngles.x;
       SkateboardAngles.z=(SkateboardAngles.z>180) ? SkateboardAngles.z-360:SkateboardAngles.z;
    
      //  SkateboardAngles.x=Mathf.Clamp(SkateboardAngles.x,-LimitRotateX,LimitRotateX);
      //  SkateboardAngles.z=Mathf.Clamp(SkateboardAngles.z,-LimitRotateZ,LimitRotateZ);

      // SkateboardAngles.x=SkateboardAngles.x==LimitRotateX ? LimitRotateX-2:SkateboardAngles.x;
      // SkateboardAngles.x=SkateboardAngles.x==-LimitRotateX ? -LimitRotateX+2:SkateboardAngles.x;
      // SkateboardAngles.z=SkateboardAngles.z==LimitRotateZ ? LimitRotateZ-2:SkateboardAngles.z;
      // SkateboardAngles.z=SkateboardAngles.z==-LimitRotateZ ? -LimitRotateZ+2:SkateboardAngles.z;

      //transform.localRotation=Quaternion.Euler(SkateboardAngles);

    // StartCoroutine(ControlReverse(SkateboardAngles.z,LimitRotateZ));
         myTools.Alarm(1,() =>
        {
        ControlReverse(SkateboardAngles.z,LimitRotateZ);
        });

   
  }

   bool isReverse(float x,float LimitRotate){
        return (x > -180 && x <= -LimitRotate) || (x >= LimitRotate &&x < 180);
    }
     void ControlReverse(float x,float LimitRotate){ 
        if(isReverse(x,LimitRotate)){
          transform.DOLocalMoveY(transform.localPosition.y+1,0);
          Vector3 currentRotation = transform.localRotation.eulerAngles;
          currentRotation.z = 0;
          currentRotation.x = 0;
          transform.localRotation = Quaternion.Euler(currentRotation);
        }
    }
 

  

      // Metod çağrısı sırasında kod bloğu (lambda ifadesi) kullanma
     


 
}
