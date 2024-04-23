using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersFactory : MonoBehaviour
{
    [SerializeField] private GameObject PlayerPrefab;
    public static event Action<GameObject> JoinGameCameraPlayer;
    public static event Action<GameObject> JoinGameCameraBot;
    public static event Action<GameObject> JoinGameCameraWeb;


    private void Start() {
        Factories.JoinGamePlayer+=CreateNewPlayer;
        Factories.JoinGameBot+=CreateNewBot;
        Factories.JoinGameWeb+=CreateNewWeb;

    }

    //ilk başta player componentsiz olsun , tipine göre burdan comp. eklenebilir.
    private void CreateNewPlayer(string name,Vector3 position,int id){
        GameObject newPlayer=Instantiate(PlayerPrefab,this.transform);
        newPlayer.gameObject.AddComponent<SkateboardMovePlayer>();
        newPlayer.gameObject.GetComponent<PlayerManager>().playerData.ID=id;
        newPlayer.transform.position=position;
        newPlayer.name=name;
        JoinGameCameraPlayer.Invoke(newPlayer);
    }

    private void CreateNewBot(string name,Vector3 position,int id){
        GameObject newPlayer=Instantiate(PlayerPrefab,this.transform);
        newPlayer.AddComponent<SkateboardMoveBot>();
        newPlayer.gameObject.GetComponent<PlayerManager>().playerData.ID=id;
        newPlayer.transform.position=position;
        newPlayer.name=name;
        JoinGameCameraBot.Invoke(newPlayer);

    }
    private void CreateNewWeb(string name,Vector3 position,int id){
        GameObject newPlayer=Instantiate(PlayerPrefab,this.transform);
        newPlayer.AddComponent<SkateboardMoveWeb>();
        newPlayer.gameObject.GetComponent<PlayerManager>().playerData.ID=id;
        newPlayer.transform.position=position;
        newPlayer.name=name;
        JoinGameCameraWeb.Invoke(newPlayer);

    }
}
