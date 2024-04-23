using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomTool;


public class RocketObjTrigger : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    // Start is called before the first frame update 


private void OnCollisionEnter(Collision other) {   
     print("rocket");

    if(other.transform.CompareTag("Player")){
        print("rocket trigger");

        Vector3 pos=this.transform.position;
        GameObject _explosion=Instantiate(explosion);
        _explosion.transform.position=pos;
        transform.localScale=new Vector3(0.01f,0.01f,0.01f);
        CustomTools mytools=new CustomTools();
        StartCoroutine(
             mytools.AlarmbyCoroutine(4f,()=>{
             Destroy(this.gameObject);
        })
        );
       
      } 
    }
}
