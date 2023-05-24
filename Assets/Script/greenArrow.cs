using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenArrow : MonoBehaviour
{
   [SerializeField] 
    private int keyNumber = 0;

    private Rigidbody2D rig;

    private bool disable = false;

    private void Start(){
        rig = GetComponent<Rigidbody2D>();
    }


    public void GreenKeyCollected(){
        EventManager.TriggerEvent("greenKeyCollected", keyNumber);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "PlayerGreen" && !disable){
            GreenKeyCollected();
            disable = true; 
            StartCoroutine(DelayedEnable());
        }
    }

    public IEnumerator DelayedEnable(){
        yield return new WaitForSeconds(0.75f);
        disable = false;
    }


}
