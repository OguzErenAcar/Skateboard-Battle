using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{

    //id ile o playerı her invoke da güncellese ? 
    private static List<Player> PlayersData ;
    private void Awake() {
        PlayersData=new List<Player>();
    }
    private void Start() {
    }
    public static void AddPlayer(Player playerData){
         print(playerData.ID+"li oyuncu eklendi");
         PlayersData.Add(playerData); 
    }

    public static List<Player> GetFriends(Player playerData){
        List<Player> a = new List<Player>();
        a =PlayersData.Where(x=>x.ID!=playerData.ID).ToList(); 
        return PlayersData.Where(x=>x!=playerData).ToList();
    }
    public static int GetID(Player playerData){
        return PlayersData.Where(x=>x==playerData).ToList()[0].ID;
    }

    public static void SetLocation(int id,Vector3 position){
         PlayersData.Find(x=>x.ID==id)._position=position;

    }
    public static Vector3 GetLocation(int id){
       return  PlayersData.Find(x=>x.ID==id)._position;

    }

 
}
