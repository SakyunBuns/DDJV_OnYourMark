using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform camera;

    void Start(){
        camera = GetComponent<Transform>();
    }

    void FixedUpdate(){
        camera.transform.position += new Vector3(0, speed, 0);
    }
}
