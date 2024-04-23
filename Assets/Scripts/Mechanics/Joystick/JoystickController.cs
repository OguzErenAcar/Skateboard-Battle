using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
   private GameObject player ;
    [SerializeField] protected SkillButtons skillbuttons;
    private GameObject rocketbutton;
    private GameObject bombbutton;
    //actionlara abone ol 

    public  event Action RocketTriggerNotActive;

    private CanvasManager Canvas;
    void Awake()
    { 
     // skillbuttons = (SkillButtons)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Models/Get/SkillButtons.asset", typeof(SkillButtons));

    }
    void Start(){  
        Canvas=transform.parent.GetComponent<CanvasManager>();
        player=Canvas.getPlayer();
        CreateButton();
        setListeners();
         SkillsController skillsController=player.transform.GetComponent<SkillsController>();
         skillsController.bombSkillevent+=Bombbotton;
         skillsController.rocketSkillevent+=Rocketbotton;
     
        
    }

    private void CreateButton(){
        rocketbutton =Instantiate(skillbuttons.rocketbutton);
        rocketbutton.transform.parent=this.transform;
        bombbutton =Instantiate(skillbuttons.bombbutton);
        bombbutton.transform.parent=this.transform;
        rocketbutton.transform.position=this.transform.position;
        bombbutton.transform.position=this.transform.position+Vector3.down*20;

        rocketbutton.GetComponent<Button>().interactable=false;
        bombbutton.GetComponent<Button>().interactable=false;
    }

    
    void setListeners(){
       rocketbutton.GetComponent<Button>().onClick.AddListener(()=>{
            player.GetComponent<SkillsController>().Rocket();
            RocketTriggerNotActive.Invoke();
            player.transform.Find("SkillTriggers/RocketTrigger").gameObject.SetActive(false);
            rocketbutton.GetComponent<Button>().interactable=false;
        });  
        bombbutton.GetComponent<Button>().onClick.AddListener(()=>{
            player.GetComponent<SkillsController>().Bomb();
            player.transform.Find("SkillTriggers/BombTrigger").gameObject.SetActive(false);
            bombbutton.GetComponent<Button>().interactable=false;

        }); 
    }

    void Rocketbotton(bool state){
        Button button=rocketbutton.GetComponent<Button>();
        player.transform.Find("SkillTriggers/RocketTrigger").gameObject.SetActive(state);
        button.interactable=state;
       
    }

    void Bombbotton(bool state){
        Button button=bombbutton.GetComponent<Button>();
        player.transform.Find("SkillTriggers/BombTrigger").gameObject.SetActive(state);
        button.interactable=state;
       
    }
    

}
