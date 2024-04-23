using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombTrigger : MonoBehaviour
{
     private PlayerManager playerData;

    private void Start() {
        playerData=transform.parent.parent.GetComponent<PlayerManager>(); 
    }

    private void OnTriggerStay(Collider other) { 
        if(other.transform.gameObject.CompareTag("Player")){
            int otherid=other.GetComponent<PlayerManager>().playerData.ID;
            playerData.FriendsSkills.Find(x=>x.ID==otherid).bomb=true;
            }
        }

    private void OnTriggerExit(Collider other) { 
        if(other.transform.gameObject.CompareTag("Player")){
            print("cıktı bomb "+other.name);
            int otherid=other.GetComponent<PlayerManager>().playerData.ID;
            playerData.FriendsSkills.Find(x=>x.ID==otherid).bomb=false;
            }
    }

    private void Update() {
        var list =playerData.FriendsSkills.Where(x=>x.bomb==true).ToList(); 
    }


}
