using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketTrigger : MonoBehaviour
{  
    private PlayerManager playerData;
    public List<Skills> list=new List<Skills>();
 
    private void Start() {
        playerData=transform.parent.parent.GetComponent<PlayerManager>(); 
    }

    private void OnTriggerStay(Collider other) { 
        if(other.transform.gameObject.CompareTag("Player")){
            int otherid=other.GetComponent<PlayerManager>().playerData.ID; 
            playerData.FriendsSkills.Find(x=>x.ID==otherid).rocket=true;
            }
        }

    private void OnTriggerExit(Collider other) { 
        if(other.transform.gameObject.CompareTag("Player")){ 
            int otherid=other.GetComponent<PlayerManager>().playerData.ID;
            playerData.FriendsSkills.Find(x=>x.ID==otherid).rocket=false; 
            }
    }

    }   
