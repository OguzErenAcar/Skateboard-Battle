using System;
using System.Collections;
using System.Collections.Generic;
using CustomTool;
using UnityEngine;

public class FlyingController : MonoBehaviour
{
    // Start is called before the first frame update

    public static event  Action onMapCollisionExit;
    public static event  Action<bool> onMapCollisionEnter;
    [SerializeField] private GameObject map;
    private bool flying=false;
    private CustomTools myTools=new CustomTools();

    private int OnCollisionCountToMap=0; 

    private void OnTriggerEnter(Collider other) {
        print(other.gameObject.name);
    }
   private void OnCollisionExit(Collision collision)
{
        OnCollisionCountToMap-=1;
        StartCoroutine(
            myTools.AlarmbyCoroutine(1f,()=>{
          //  print("sure");
            if(OnCollisionCountToMap<1){
            onMapCollisionExit?.Invoke();
            print("slow");
            flying=true;
            }
            }));
}

   private void OnCollisionEnter(Collision collision)
{
    
       // print("start");
        OnCollisionCountToMap+=1;
        if(flying){
            onMapCollisionEnter?.Invoke(true);
            flying=false;
        }
    
}


}
