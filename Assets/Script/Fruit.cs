using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit: MonoBehaviour
{
    private Animator animator;
    private string[] fruitAnimations;
    private float speed = 2.5f;


    void Start()
    {   
        fruitAnimations = new string[]{"banana", "anana", "fraise", "melon", "kiwi", "orange", "cerise"};
        animator = GetComponent<Animator>();
        PlayRandomAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayRandomAnimation()
    {
        string randomAnimation = fruitAnimations[Random.Range(0, fruitAnimations.Length)];
        animator.SetTrigger(randomAnimation);
    }

    public void SetDirection(Vector2 direction)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction.normalized * speed;
    }
}