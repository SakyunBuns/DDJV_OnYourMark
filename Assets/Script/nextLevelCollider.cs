using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class nextLevelCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "PlayerRed"){
            EventManager.TriggerEvent("RedOut","RedOut");
        }else if(other.gameObject.tag == "PlayerGreen"){
            EventManager.TriggerEvent("GreenOut","GreenOut");   
        }
    }
}
