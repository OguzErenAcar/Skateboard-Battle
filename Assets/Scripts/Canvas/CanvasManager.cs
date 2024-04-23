using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CanvasManager : MonoBehaviour{
    private GameObject player;
    private Camera camera_; 
    public void setPlayer(GameObject _player){ 
        player=_player;
    }
    public GameObject getPlayer(){
        return player;
    }
    public void setCamera(Camera camera){
        camera_=camera;
    }
    public Camera getCamera(){
        return camera_;
    }
}

