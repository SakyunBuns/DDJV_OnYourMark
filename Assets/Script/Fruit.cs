using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit: MonoBehaviour
{
    private Animator animator;
    private string[] fruitAnimations;
    private float speed = 2.5f;
    private bool deleteMe = false; 

    void Start()
    {   
        fruitAnimations = new string[]{"banana", "anana", "fraise", "melon", "kiwi", "orange", "cerise"};
        animator = GetComponent<Animator>();
        PlayRandomAnimation();
        StartCoroutine(RemoveMe());
    }

    void FixedUpdate()
    {
        if (deleteMe)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a -= Time.fixedDeltaTime;
            spriteRenderer.color = color;

            if (color.a <= 0f)
            {
                Destroy(gameObject);
            }
        }
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

    private IEnumerator RemoveMe(){
        yield return new WaitForSeconds(3.0f);
        deleteMe = true;
    }
}