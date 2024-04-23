using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
 
 public  Player playerData;
 public List<Skills> FriendsSkills;
 //bu paylaşılması gerekmiyecek bir liste o yüzden ayrı 

    private void Awake() {
        playerData =new Player();
        FriendsSkills=new List<Skills>(); 
        playerData.name=this.transform.name;
        
        //GET MY ID 
    }
    private void Start() {
        
       PlayersManager.AddPlayer(playerData); 
       print("_____");
      // playerData.ID=PlayersManager.GetID(playerData);
        Factories.CreatedAllPlayer+=SetFriendsSkills;

     
    }

    private void Update() {
        PlayersManager.SetLocation(playerData.ID,transform.position);
        playerData._position=PlayersManager.GetLocation(playerData.ID);
    } 

    private void SetFriendsSkills(){

        var list = PlayersManager.GetFriends(playerData);

       foreach (var item in list)
       {
        Skills x=new Skills();
        x.ID= item.ID;
        x.name=item.name;
        FriendsSkills.Add(x);
       }
    }
}
