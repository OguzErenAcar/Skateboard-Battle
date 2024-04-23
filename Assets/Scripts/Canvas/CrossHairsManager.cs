using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;


public class CrossHairsManager : MonoBehaviour
{
    private Camera camera_; 
    private PlayerManager player;
    [SerializeField] GameObject crossHair;
    private CanvasManager Canvas;
    private List<GameObject> crossHairlist=new List<GameObject>();
    private List<Skills> RocketTriggerList=new List<Skills>();


    //burası playyerdataya göre dönmeli

    private void Awake() {    
       // crossHair = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/CrossHair.prefab", typeof(GameObject)); 
    }
    void Start()
    {     
        Canvas=transform.parent.GetComponent<CanvasManager>(); 
        player=Canvas.getPlayer().GetComponent<PlayerManager>();
        camera_=Canvas.getCamera();
        Canvas.transform.Find("Buttons").GetComponent<JoystickController>().RocketTriggerNotActive+=DeleteAll;
        RocketTriggerList=player.FriendsSkills.Where(x=>x.rocket==true).ToList(); 
        CreateCrosshair();
    }

    // Update is called once per frame


    void Update()
    {

        RocketTriggerList=player.FriendsSkills.Where(x=>x.rocket==true).ToList(); 
        UpdateCrosshairList();
        ShowCrossHair();
  
    }


    private void ShowCrossHair(){
        int j =0;
        foreach (var item in RocketTriggerList)
        {
         Vector3 position=PlayersManager.GetLocation(item.ID);
         try
         {
            crossHairlist[j].transform.position= camera_.WorldToScreenPoint(position);
          }
         catch (System.Exception){
            
            Destroy(crossHairlist.Last());
            crossHairlist.Remove(crossHairlist.Last());
           
         } 
        j++;
       }

    }

    private void CreateCrosshair(){

        for (int i = 0; i < RocketTriggerList.Count; i++)
        {
            GameObject _crosshair=Instantiate(crossHair,this.transform);
            crossHairlist.Add(_crosshair);
        }

    }

    private void UpdateCrosshairList(){
        if(RocketTriggerList.Count>crossHairlist.Count){
            GameObject _crosshair=Instantiate(crossHair,this.transform);
            crossHairlist.Add(_crosshair);
        }
        else if(RocketTriggerList.Count<crossHairlist.Count){
            Destroy(crossHairlist.Last());
            crossHairlist.Remove(crossHairlist.Last());
            
        }

    }
    private void DeleteAll(){
       foreach (GameObject obj in crossHairlist) {
        Destroy(obj);
        }
        crossHairlist.Clear();
    }
}
