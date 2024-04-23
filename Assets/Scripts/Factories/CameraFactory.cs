using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFactory : MonoBehaviour
{
    [SerializeField] private GameObject CameraPrefab; 
    public static event Action<GameObject,GameObject> JoinGameCanvasPlayer;
    public static event Action<GameObject> JoinGameCanvasBot;
    public static event Action<GameObject> JoinGameCanvasWeb;




    private void Start() {
        PlayersFactory.JoinGameCameraPlayer+=CreateNewPlayerCameraPlayer;
        PlayersFactory.JoinGameCameraBot+=CreateNewPlayerCameraBot;
        PlayersFactory.JoinGameCameraWeb+=CreateNewPlayerCameraWeb;

    }

    private void CreateNewPlayerCameraPlayer(GameObject _player){ 
        GameObject newPlayerCamera=Instantiate(CameraPrefab,this.transform);
        newPlayerCamera.name=_player.name+"Camera";
        newPlayerCamera.GetComponent<CameraMove>().setPlayer(_player);
        JoinGameCanvasPlayer.Invoke(_player,newPlayerCamera);
    }
    
    private void CreateNewPlayerCameraBot(GameObject _player){
        JoinGameCanvasBot.Invoke(_player);
    }
    private void CreateNewPlayerCameraWeb(GameObject _player){
        JoinGameCanvasWeb.Invoke(_player);

    }
    
}
