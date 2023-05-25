using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadTextGreen : MonoBehaviour
{
    private UnityAction<object> ev_greenDeath;
    private TMP_Text text;


    void Start()
    {
        ev_greenDeath = new UnityAction<object>(Dead);
        EventManager.StartListening("GreenBeenHit", ev_greenDeath);
        text = GetComponent<TMP_Text>();
    }

    void Dead(object someObject)
    {
        text.text = "Dead";
        text.color = Color.red;
    }

}
