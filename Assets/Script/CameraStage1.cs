using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CameraStage1 : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform m_camera;

    private bool checkPoint = false;



    void Start(){
        m_camera = GetComponent<Transform>();
    }

    void FixedUpdate(){
        if (m_camera.transform.position.y > 14 && m_camera.transform.position.y < 35){
            m_camera.transform.position += new Vector3(0, speed/3.5f, 0);
        } 
        else if(m_camera.transform.position.y >= 46){
            speed = 0;
        }
        else{
            m_camera.transform.position += new Vector3(0, speed, 0);
        }

        if(m_camera.transform.position.y > 0 && checkPoint == false){
            checkPoint = true;
            EventManager.TriggerEvent("checkPoint", "checkPoint");
        }

    
    }
}
