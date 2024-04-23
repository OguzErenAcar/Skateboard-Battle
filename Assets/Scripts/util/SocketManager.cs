using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SocketManager :MonoBehaviour
{
 public static SocketIOUnity socket;
 public static string serverUrlLink = "http://localhost:3000";
 public static string GameState="Awake";
[SerializeField] private string mynickname="oguz";
    private  void Awake() {

    var uri = new Uri(serverUrlLink);       
    socket = new SocketIOUnity(uri); 
     
      socket.OnConnected += (sender, e) => 
        {
        print("socket.OnConnected"); 
        socket.Emit("join", mynickname);
        };

       socket.On("GameState", response =>{
             switch (response.GetValue<string>())
            {
                case "Awake":
                    GameState="Awake"; 
                    print("Awake");
                    break;
                case "EveryoneConnected":
                    GameState="EveryoneConnected"; 
                    print("EveryoneConnected");
                    socket.Emit("GetMyInfo");
                   
                    break;
                case "Ready":
                    GameState="Ready"; 
                    print("Ready");
                     socket.Emit("GetFriendsInfo");
                    break;
                case "Start":
                    GameState="Start"; 
                    print("Start");
                    //iputlar gönderilmeye başlar 
                    break;
                default:
                    print("Geçersiz Gamestate");
                    break;
            }
        });  
       socket.Connect();
     }

    void OnDestroy()
    {
        socket.Disconnect();
        Debug.Log("destroy connection");
    }

}
