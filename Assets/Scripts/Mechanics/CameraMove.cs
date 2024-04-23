using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;



public class CameraMove : MonoBehaviour
{ 

    
    // Start is called before the first frame update
    [SerializeField] private float radius =3;
    private Vector3 currentPositionDiference;
    private Transform player;//action ile atama ypasak mesela ? her kullanıcı için farklı olacakmı 

      public void setPlayer(GameObject _player){
        player=_player.transform;
    }
    public Transform getPlayer(){
        return player.transform;
    }
   
    void Start()
    {
        
         currentPositionDiference=new Vector3(player.position.x,player.position.y+2,player.position.z-3.5f);
         transform.position=currentPositionDiference;
        // transform.LookAt(Skateboard);
         transform.localEulerAngles=new Vector3(20,0,0);  
    }

    // Update is called once per frame
    void Update()
    {   
        // currentPositionDiference=new Vector3(Skateboard.position.x,Skateboard.position.y+2,Skateboard.position.z-2.5f);
        
        Vector3 SkateboardAngles= player.rotation.eulerAngles; 

        transform.localEulerAngles=new Vector3(20,SkateboardAngles.y,0); 
        float x=player.position.x+Mathf.Sin((SkateboardAngles.y+180)* Mathf.PI/180)*radius;
        float y=player.position.y+2;
        float z=player.position.z+Mathf.Cos((SkateboardAngles.y+180)* Mathf.PI/180)*radius;

        transform.DOMoveX(x,1f);
        transform.DOMoveY(y,0);
        transform.DOMoveZ(z,1f); 
        //burda dönme ve gidişi ayrı ayrı eklersek dönüş titremesi de kalkar 

        // transform.position = Vector3.Lerp(transform.position, currentPositionDiference, 0.15f);
       // transform.rotation = Quaternion.Euler(new Vector3(20, transform.rotation.eulerAngles.y, 0));
        // HorizontalInput=Input.GetAxis("Horizontal");
        // ForwardInput=Input.GetAxis("Vertical"); 
        // Objeyi merkez objesine göre döndürün 
        //transform.parent.eulerAngles=Vector3.right*Time.deltaTime*HorizontalInput*rotate;
         //transform.RotateAround(Skateboard.position, Vector3.up, Time.deltaTime*HorizontalInput*rotate); 
        // float SkateboardMove=Mathf.Abs(Vector3.Distance(this.transform.position,Skateboard.transform.position)*Speed);
        // transform.position= Vector3.MoveTowards(transform.position,currentPositionDiference,SkateboardMove*Time.deltaTime);
    }
}
