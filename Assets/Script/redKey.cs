using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redKey : MonoBehaviour
{

    [SerializeField] 
    private int keyNumber = 0;

    private Rigidbody2D rig;

    private void Start(){
        rig = GetComponent<Rigidbody2D>();
    }


    public void RedKeyCollected(){
        EventManager.TriggerEvent("redKeyCollected", keyNumber);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "PlayerRed"){
            RedKeyCollected();
            GameObject redKeySpot = rig.transform.parent.gameObject;
            DestroyChildObject(redKeySpot, "RedKey");
            DestroyChildObject(redKeySpot, "KeyShadow");
        }
    }

    private void DestroyChildObject(GameObject parentObject, string childObjectName)
    {
        Transform childTransform = parentObject.transform.Find(childObjectName);
        if (childTransform != null)
        {
            GameObject childObject = childTransform.gameObject;
            Destroy(childObject);
        }
    }
}
