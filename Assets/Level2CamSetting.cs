using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2CamSetting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform player1;
    [SerializeField]
    private Transform player2;

    private bool condition1 = false;
    private bool condition2 = false;

    [SerializeField]
    private float speed;

    private Transform m_camera;

    void Start()
    {
        m_camera = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float posX = 0;
        if (player1.position.y >= 5 || player2.position.y >= 5 && !condition1)
        {
            speed = 0.02f;
            condition1 = true;
        }
        if (player1.position.y >= 15 || player2.position.y >= 15 && !condition2)
        {
            speed = 0.02f;
            condition2 = true;
            posX = (player1.position.x + player2.position.x) / 2;
        }
        print(posX );
        m_camera.transform.position = new Vector3(posX, m_camera.transform.position.y, m_camera.transform.position.z);
        m_camera.transform.position += new Vector3(0, speed, 0);
    }
}
