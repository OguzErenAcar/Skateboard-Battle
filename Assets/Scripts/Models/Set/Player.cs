using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "player")]
public class Player : ScriptableObject 

{
    public int ID =-1;
    public string _name=null; 
    public Vector3 _position=Vector3.zero;
   
    //bunu player kendisi dolduracak skilltriggerların içindemi değilmi diye 
}
