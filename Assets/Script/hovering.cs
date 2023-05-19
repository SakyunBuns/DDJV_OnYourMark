using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hovering : MonoBehaviour
{
    [SerializeField]
    private float hoverHeight = 0.3f;
    [SerializeField]
    private float hoverSpeed = 1.0f; 

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {

        float newY = originalPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;


        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }
}
