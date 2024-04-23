using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class Factories :MonoBehaviour
{
//Sahnede olanlar 
public static  GameObject Map;
public static GameObject  SkillLocations;
public static  GameObject  SkillFactory;
public static GameObject  PlayersFactory;
public static GameObject  CameraFactory;

[SerializeField] private GameObject PlayerLocations;
private List<Vector3> Locations=new List<Vector3>();
// [SerializeField] private  GameObject  CanvasFactory;
// [SerializeField] private  GameObject  CameraFactory;

public static event Action<string,Vector3,int > JoinGamePlayer;
public static event Action<string,Vector3, int > JoinGameBot;
public static event Action<string,Vector3,int > JoinGameWeb;

public static event Action CreatedAllPlayer;


private static PlayerWeb MyWebInfo;
private static JArray FriendsWebInfo;



private void Awake() {
    Map=GameObject.Find("Map");
    SkillLocations=GameObject.Find("SkillLocations");
    SkillLocations=GameObject.Find("SkillFactory");
    PlayersFactory=GameObject.Find("PlayersFactory");
    CameraFactory=GameObject.Find("CameraFactory");

    foreach (Transform item in PlayerLocations.transform)
    {
        Locations.Add(item.position);
    }
}

private IEnumerator Start() {
  SetSocketPlayer();  
  yield return new WaitForSeconds(2f); 
    JoinGamePlayer.Invoke(MyWebInfo.Username,Locations[MyWebInfo.ID-1],MyWebInfo.ID);
   
   if(FriendsWebInfo!=null){
    foreach (var item in FriendsWebInfo){
     var obj = JsonConvert.DeserializeObject<PlayerWeb>(item[0].ToString());
     int id=obj.ID;
     JoinGameWeb.Invoke(obj.Username,Locations[id-1],id); 
    }
   }
    
   
    yield return new WaitForSeconds(5f); 
    CreatedAllPlayer.Invoke();
}
 

private void SetSocketPlayer(){

  SocketManager.socket.On("MyInfo", (response) =>{
    string jsonStr = response.ToString(); // Socket.IO yanıtını bir JSON string'e dönüştürün
    print(jsonStr);
    var obj = JsonConvert.DeserializeObject<PlayerWeb>(jsonStr.Substring(1, jsonStr.Length - 2));
    int id=obj.ID;
    print(obj.Username+" "+Locations[id-1]+" "+id);
    MyWebInfo=obj;
 }); 
  SocketManager.socket.On("FriendsInfo", response =>{
    JArray jsonArray = JArray.Parse(response.ToString());
    jsonArray=FriendsWebInfo;
    
 }); 
  
}
 

}
