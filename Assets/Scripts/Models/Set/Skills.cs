using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skills", menuName = "skills")]
public class Skills : ScriptableObject
{
    public int ID =0;
    public string _name=null  ; 
    public bool rocket=false;
    public bool bomb=false;
}
