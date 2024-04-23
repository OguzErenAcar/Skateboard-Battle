using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomTool;

public class SkillRocket : SkillManager
{
    // Start is called before the first frame update
   private Vector3 Startposition;
   private Texture texture;
   private CustomTools mytool=new CustomTools();

    void Start()
    {
        string texturePath = "textures/rocket"; // Klasör adı ve dosya adı
        texture = Resources.Load<Texture>(texturePath);
        GetComponent<Renderer>().material.SetTexture("_BaseMap", texture);

        Startposition=transform.position;
        //print(GetTexture(0));
      //  GetComponent<Renderer>().material.SetTexture("_BaseMap", GetTexture(0));

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
