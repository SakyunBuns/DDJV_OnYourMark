using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class passCheckPoint : MonoBehaviour
{
    private UnityAction<object> ev_checkPoint;


    void Start()
    {
        ev_checkPoint = new UnityAction<object>(CheckPoint);
        EventManager.StartListening("checkPoint", ev_checkPoint);
    }

    private void CheckPoint(object obj)
    {
        Destroy(gameObject);
    }

}
