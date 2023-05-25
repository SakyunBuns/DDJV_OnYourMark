using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilChicken : MonoBehaviour
{
    private bool m_facingRight = true;

    private Rigidbody2D m_rig;
    private Animator m_anim;

    [SerializeField]
    public float m_speed;
    private Vector2 m_movement;

    [SerializeField]
    private Transform player1;
  
    [SerializeField]
    private float m_lineLength;

    private Vector3 rayDirection1;

    private bool m_seeingPlayer;

    [SerializeField]
    private Transform seenFX;

    // Start is called before the first frame update
    void Start()
    {
        m_rig = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_movement.x != 0 || m_movement.y != 0)
        {
            m_anim.SetBool("isWalking", true);
            m_anim.SetFloat("Horizontal", m_movement.x);
            m_anim.SetFloat("Vertical", m_movement.y);
        }
        else m_anim.SetBool("isWalking", false);
    }

    private void FixedUpdate()
    {
        rayDirection1 = (player1.position - transform.position).normalized;

        RaycastHit2D hit2DWallPlayerOne = Physics2D.Raycast(transform.position, rayDirection1, m_lineLength, LayerMask.GetMask("Wall"));
      

        float lineLengthJoueur = m_lineLength;
        bool didHitWall = false;

        if (hit2DWallPlayerOne.collider != null)
        {
            //didHitWall = true;
            lineLengthJoueur = hit2DWallPlayerOne.distance;
        }

        RaycastHit2D hit2DPlayerOne = Physics2D.Raycast(transform.position, rayDirection1, m_lineLength, LayerMask.GetMask("Player"));
        

        if (hit2DPlayerOne.collider != null && !didHitWall)
        {
            m_seeingPlayer = true;
            m_movement =  rayDirection1;
        }
        else
        {
            if (m_seeingPlayer)
            {
                //StartCoroutine(Errance());
                m_seeingPlayer = false;
                Instantiate(seenFX, transform.position + Vector3.down, Quaternion.identity);
            }
        }

        m_rig.velocity = m_movement * m_speed;
        m_rig.velocity = m_rig.velocity.normalized * m_speed;

        float h = m_anim.GetFloat("Horizontal");
        if (h > 0 && m_facingRight)
        {
            Flip();
        }
        else if (h < 0 && !m_facingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Interactable")
        {
            Destroy(gameObject);
        }

    }
    //IEnumerator Errance()
    //{
    //    while (true)
    //    {
    //        m_movement = Vector2.zero;
    //        m_anim.SetBool("isWalking", false);
    //        yield return new WaitForSeconds(Random.Range(0.8f, 2.0f));
    //        m_movement = Random.insideUnitSphere;
    //        m_movement /=10 ;
    //        yield return new WaitForSeconds(Random.Range(0.2f, 1.0f));
    //    }
    //}

    private void Flip()
    {
        m_facingRight = !m_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
