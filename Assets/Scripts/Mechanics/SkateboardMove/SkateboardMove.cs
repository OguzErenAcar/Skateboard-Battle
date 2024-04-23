using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using CustomTool;



public class SkateboardMove : MonoBehaviour
{   

   //protected GameObject Wheels;
   [SerializeField] protected float rotateSpeed=50;
   [SerializeField] protected float Speed=10;
   [SerializeField] protected float LimitRotateX=120;
   [SerializeField] protected float LimitRotateZ=70;
   [SerializeField] protected float slowdownTime=5;
   [SerializeField] protected float AccelerationTime=2;


   protected float _rotateSpeed;
   protected float _Speed;
   protected bool isSlowStop;
   protected bool isAcceleration;
   protected float time ;

  protected float HorizontalInput;
  protected float ForwardInput; 
   protected CustomTools myTools=new CustomTools();
   protected void Start(){ 
      _rotateSpeed=rotateSpeed;
      _Speed=Speed;
      isAcceleration=true;
      FlyingController flyingController =this.transform.GetComponent<FlyingController>();
      flyingController.onMapCollisionExit+=StopRotate; 
      flyingController.onMapCollisionEnter+=isAccelerationMoveAction;  
    }
   protected void Update()
    { 
         Move();
         RotateLimited();
         if(isSlowStop)
            SlowStopMove();
         if(isAcceleration)
            StartMove();
    }

  
    protected void StopRotate(){
      isSlowStopMoveAction(true);
      rotateSpeed=0;
      Vector3 angels =transform.localRotation.eulerAngles;
      Quaternion quaternion=Quaternion.Euler(angels.x,angels.y,0);
      transform.DOLocalRotateQuaternion(quaternion,0.2f);
   }
    protected void StartMove(){
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

   protected void SlowStopMove(){
            time += Time.deltaTime;
            Speed = Mathf.Lerp(Speed, 0f, time / slowdownTime);

            if (time >= slowdownTime)
            {
                Speed = 0f;
                isSlowStop = false;
                time=0;
            }
   }
   protected void isSlowStopMoveAction(bool state ){
        isSlowStop=state;
   }
    protected void isAccelerationMoveAction(bool state ){
        isAcceleration=state;
   }

   

    protected void StopMove(){
          rotateSpeed=0;
          Speed=0;
      }
   public virtual void Move(){
         HorizontalInput=Input.GetAxis("Horizontal");
         ForwardInput=Input.GetAxis("Vertical"); 
       //transform.eulerAngles+=transform.eulerAngles*Time.deltaTime*HorizontalInput*rotate;
        Vector3 HorizantalVector=Vector3.up*Time.deltaTime*HorizontalInput*rotateSpeed;
        Vector3 VerticalVector=transform.forward*Time.deltaTime*ForwardInput*Speed;
       // rigidbody_.AddForce(Vector3.forward*ForwardInput*Speed); 
        transform.Rotate(HorizantalVector,Space.Self);
        transform.Translate(VerticalVector,Space.World); 

    }
   


    protected void RotateLimited(){
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
