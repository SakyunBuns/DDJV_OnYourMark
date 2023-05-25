using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadTextRed : MonoBehaviour
{
    private UnityAction<object> ev_redDeath;
    private TMP_Text text;


    void Start()
    {
        ev_redDeath = new UnityAction<object>(Dead);
        EventManager.StartListening("RedBeenHit", ev_redDeath);
        text = GetComponent<TMP_Text>();
    }

    void Dead(object someObject)
    {
        text.text = "Dead";
        text.color = Color.red;
    }

}
