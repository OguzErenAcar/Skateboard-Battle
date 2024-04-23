using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New SkillAttributes",menuName ="Skill Attributes")]
public class SkillAttributes : ScriptableObject
{
//skilllerin konumlarını tutan ve default tasarım tutan yer  
public GameObject prefabskill ;
public Color defaultColor = Color.yellow;
public Texture[] textures;
public Texture bomb ;
}
