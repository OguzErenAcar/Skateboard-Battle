using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SkillAttributes attributes=null ;
    private GameObject SkillLocations ;
    private List<Transform> Locations = new List<Transform>();

    
    
    void Awake(){
    SkillLocations=GameObject.Find("SkillLocations");
    foreach (Transform child in SkillLocations.transform)
    {
        Locations.Add(child); 
    }
    }

    void Start()
    {
        //yeni objeleri oluşturma ve bunlara skilleri atama 
        List<GameObject> skills=new List<GameObject>();

        foreach (Transform item in Locations)
        {   
            GameObject new_skill=Instantiate(attributes.prefabskill);
            new_skill.transform.parent=item;
            new_skill.transform.position=item.position;
            new_skill.GetComponent<Renderer>().material.color=attributes.defaultColor;
            new_skill.GetComponent<BoxCollider>().isTrigger=true;
            skills.Add(new_skill);
            
        }
         
         skills[0].transform.gameObject.AddComponent<SkillRocket>();
         skills[1].transform.gameObject.AddComponent<SkillBomb>();
         skills[2].transform.gameObject.AddComponent<SkillRocket>();
         skills[3].transform.gameObject.AddComponent<SkillBomb>();

    }
 
   
    protected void MoveSkill(Vector3 position){
       // Vector3 position=new Vector3(transform.position.x,transform.position.y+1,transform.position.z);
        transform.DOJump(position,0.2f,2,1);
        transform.DORotate(Vector3.up*(transform.eulerAngles.y+180),1);
    }
  

}
