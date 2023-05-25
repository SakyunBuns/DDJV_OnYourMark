using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class pseudoTeleporter : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "PlayerRed"){
            EventManager.TriggerEvent("pseudoTeleporterRed", "pseudoTeleporterRed");
        }else if(other.gameObject.tag == "PlayerGreen"){
            EventManager.TriggerEvent("pseudoTeleporterGreen", "pseudoTeleporterGreen");   
        }
    }

}
