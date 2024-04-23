using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CanvasFactory : MonoBehaviour
{
   [SerializeField] private GameObject CanvasPrefab;
   

    private void Start() {
        
        CameraFactory.JoinGameCanvasPlayer+=CreateNewPlayerCanvasPlayer;
        CameraFactory.JoinGameCanvasBot+=CreateNewPlayerCanvasBot;
        CameraFactory.JoinGameCanvasWeb+=CreateNewPlayerCanvasWeb;

    }

    private void CreateNewPlayerCanvasPlayer(GameObject _player,GameObject _camera){
       
        Camera Camera=_camera.GetComponent<Camera>();
        GameObject newPlayer=Instantiate(CanvasPrefab,this.transform);
        newPlayer.name=_player.name+"Canvas";

        newPlayer.transform.Find("Buttons").AddComponent<JoystickControllerPlayer>(); 
         newPlayer.transform.Find("CrossHairs").AddComponent<CrossHairsManager>();
        newPlayer.GetComponent<CanvasManager>().setPlayer(_player);
        newPlayer.GetComponent<CanvasManager>().setCamera(Camera);

        
    }

     private void CreateNewPlayerCanvasBot(GameObject _player){
        GameObject newPlayer=Instantiate(CanvasPrefab,this.transform);
        newPlayer.name=_player.name+"Canvas";
        newPlayer.transform.Find("Buttons").AddComponent<JoystickControllerBot>(); 
        newPlayer.GetComponent<Canvas>().enabled=false;
        newPlayer.GetComponent<CanvasManager>().setPlayer(_player);

        
    }
     private void CreateNewPlayerCanvasWeb(GameObject _player){
        GameObject newPlayer=Instantiate(CanvasPrefab,this.transform);
        newPlayer.name=_player.name+"Canvas";
        newPlayer.transform.Find("Buttons").AddComponent<JoystickControllerBot>(); 
        newPlayer.GetComponent<Canvas>().enabled=false;
        newPlayer.GetComponent<CanvasManager>().setPlayer(_player);
    }
}
