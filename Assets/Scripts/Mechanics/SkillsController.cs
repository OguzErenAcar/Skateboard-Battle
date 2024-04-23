using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class SkillsController : MonoBehaviour
{
    //player üzerinde

    public  event Action<bool> bombSkillevent;
    public  event Action<bool> rocketSkillevent; 

    [SerializeField] private GameObject RocketPrefab;  

    private PlayerManager playerData;
    private int bombcount=0;
    private int rocketcount=0;
    private List<Skills> RocketTriggerList =new List<Skills>();
 
    private void Start() {  
       playerData= transform.GetComponent<PlayerManager>();
        RocketTriggerList =playerData.FriendsSkills.Where(x=>x.rocket==true).ToList(); 
    }

    private void Update() {
        RocketTriggerList =playerData.FriendsSkills.Where(x=>x.rocket==true).ToList(); 
  
    }
    public void bombSkill(bool value){ 
         if(bombcount<1)  {
            bombSkillevent.Invoke(value); 
            bombcount++;
         }    
    }
    public void rocketSkill(bool value){
        if(rocketcount<1){
            rocketSkillevent.Invoke(value); 
            rocketcount++;
        }    
    }

    public void Rocket(){
        rocketcount-=1;
        
        if(RocketTriggerList.Count>0){ 
            GameObject _rocket= Instantiate(RocketPrefab);
            _rocket.transform.position=this.transform.position+Vector3.up;
            int id=RocketTriggerList.Last().ID;
            Vector3 target =PlayersManager.GetLocation(id)+Vector3.up/2;
            Vector3 hedefYon = target - _rocket.transform.position;
            _rocket.transform.rotation = Quaternion.LookRotation(hedefYon)* Quaternion.Euler(90, 0, 0);
            _rocket.transform.DOMove(target,1);  

        }

    }

    public void Bomb(){
        bombcount-=1;
    }

    //skilleri yaz button Inspectorden sec 
}
