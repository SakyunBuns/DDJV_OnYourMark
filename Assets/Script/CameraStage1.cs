using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStage1 : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform m_camera;

    void Start(){
        m_camera = GetComponent<Transform>();
    }

    void FixedUpdate(){
        if (m_camera.transform.position.y > 14 && m_camera.transform.position.y < 35){
            m_camera.transform.position += new Vector3(0, speed/3.5f, 0);
        } 
        else{
            m_camera.transform.position += new Vector3(0, speed, 0);
        }

    
    }
}