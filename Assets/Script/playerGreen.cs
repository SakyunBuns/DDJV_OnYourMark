using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class playerGreen : MonoBehaviour
{
    private bool m_facingRight = false;

    private Rigidbody2D rig;
    private Animator anim;

    public float vitesse;
    private Vector2 movement;

    [SerializeField]
    private float force;

    private bool controlerOn = true;

    private UnityAction<object> ev_teleporter;
    private UnityAction<object> ev_out;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        ev_teleporter = new UnityAction<object>(Teleportation);
        ev_out = new UnityAction<object>(Out);

        EventManager.StartListening("pseudoTeleporterGreen", ev_teleporter);
        EventManager.StartListening("GreenOut", ev_teleporter);
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isDead") == false && controlerOn){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");


            if (movement.x != 0 || movement.y != 0)
            {
                anim.SetBool("isWalking", true);
                anim.SetFloat("horizontal", movement.x);
                anim.SetFloat("vertical", movement.y);
            }
            else anim.SetBool("isWalking", false);
        }

        else if(!controlerOn){
            movement.x = 0;
            movement.y = 1;
            rig.transform.rotation *= Quaternion.Euler(0, 0, 1.0f);
        }
    }

    private void FixedUpdate()
        {
            rig.velocity = movement * vitesse;
            rig.velocity = rig.velocity.normalized * vitesse;

            float h = anim.GetFloat("horizontal");
        if (h > 0 && m_facingRight)
        {
            Flip();
        }
        else if (h < 0 && !m_facingRight) {
            Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy" || LayerMask.LayerToName(collision.gameObject.layer) == "Camera" )
        {
            EventManager.TriggerEvent("GreenBeenHit", transform.position);
            anim.SetBool("isDead", true);
        }

            //if (LayerMask.LayerToName(collision.gameObject.layer) == "Declancheur")
            //{
            //    Vector2 pushDirection = Vector2.zero;
            //    if (collision.gameObject.CompareTag("Top"))
            //    {
            //        pushDirection = Vector2.down;
            //    }
            //    else if (collision.gameObject.CompareTag("Bottom"))
            //    {
            //        pushDirection = Vector2.up;
            //    }
            //    else if (collision.gameObject.CompareTag("Right"))
            //    {
            //        pushDirection = Vector2.left;
            //    }
            //    else
            //    {
            //        pushDirection = Vector2.right;
            //    }
            //    pushDirection.Normalize();
            //    collision.transform.parent.GetComponent<Rigidbody2D>().AddForce(pushDirection * force, ForceMode2D.Impulse);
            //}
            //else if (LayerMask.LayerToName(collision.gameObject.layer) == "Ennemi")
            //{
            //    StartCoroutine(Death());
            //}
            //else if (LayerMask.LayerToName(collision.gameObject.layer) == "Victory")
            //{
            //    movement = Vector2.zero;
            //    anim.SetBool("dancing", true);
            //    StartCoroutine(danceVictory());
            //}
        }

    public IEnumerator Death()
    {
        anim.SetBool("isDead", true);
        //Instantiate(prefabNugget, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        //StartCoroutine(fondu.GetComponent<FonduEntree>().FonduFin());
        yield return new WaitForSeconds(2.0f);
            
    }

    IEnumerator danceVictory()
    {
        float randFloat = Random.Range(0.5f, 1.5f);
        yield return new WaitForSeconds(Random.Range(0.8f, 2.0f));
        movement = Random.insideUnitSphere;
        yield return new WaitForSeconds(randFloat);
        movement = Random.insideUnitSphere;
        StartCoroutine(danceVictory());
    }

    public void Teleportation(object teleporter)
    {
        controlerOn = false;
    }

    private void Flip() {
        m_facingRight = !m_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }    
    
    public void Out(object obj)
    {
        Destroy(gameObject);
    }
}
