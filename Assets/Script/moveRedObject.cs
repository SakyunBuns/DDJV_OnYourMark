using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class moveRedObject : MonoBehaviour
{
    [SerializeField]
    private float objectNumber = 0;

    [SerializeField]
    private float force = 10;

    [SerializeField]
    private string direction;

    private Rigidbody2D rig;
    private UnityAction<object> ev_keyCollected;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        ev_keyCollected = new UnityAction<object>(RedKeyCollected);

        EventManager.StartListening("redKeyCollected", ev_keyCollected);
    }


    private void RedKeyCollected(object keyNumber)
    {
        if ((int)keyNumber == objectNumber)
        {
            // rig.bodyType = RigidbodyType2D.Dynamic;
            if (direction == "UP")
            {
                rig.AddForce(Vector2.up * force);
            }
            else if (direction == "DOWN")
            {
                rig.AddForce(Vector2.down * force);
            }
            else if (direction == "LEFT")
            {
                rig.AddForce(Vector2.left * force);
            }
            else if (direction == "RIGHT")
            {
                rig.AddForce(Vector2.right * force);
            }
            else
            {
                Debug.Log("Invalid direction");
            }
            // StartCoroutine(SwitchToFixed());      
        }
    }
    // private IEnumerator SwitchToFixed(){
    //     yield return new WaitForSeconds(1.0f);
    //     rig.bodyType = RigidbodyType2D.Static;
    // }
}
