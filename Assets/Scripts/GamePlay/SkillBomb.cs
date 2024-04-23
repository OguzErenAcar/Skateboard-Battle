using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomTool;

public class SkillBomb : SkillManager 
{ 

    private Vector3 Startposition;
    private CustomTools mytool=new CustomTools();
    [SerializeField] private Texture texture;

    void Start()
    { 
        string texturePath = "textures/bomb"; // Klasör adı ve dosya adı
        texture = Resources.Load<Texture>(texturePath);
        GetComponent<Renderer>().material.SetTexture("_BaseMap", texture);
        Startposition=transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        mytool.Alarm(3,()=>{
            base.MoveSkill(Startposition);
        });
    }

      protected void OnTriggerEnter(Collider other) {
        print(other.name);
    }


}
