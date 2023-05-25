using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraScript : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform m_camera;

    void Start(){
        m_camera = GetComponent<Transform>();
    }

    void FixedUpdate(){
        m_camera.transform.position += new Vector3(0, speed, 0);
    }
}
