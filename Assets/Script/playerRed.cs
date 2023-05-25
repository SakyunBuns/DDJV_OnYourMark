using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class playerRed : MonoBehaviour
{
    private bool m_facingRight = false;

    private Rigidbody2D rig;
    private Animator anim;

    public float vitesse;
    private Vector2 movement;

    [SerializeField]
    private float force;

    [SerializeField]
    private Transform prefabFruit;

    private bool controlerOn = true;
    private bool canFire = true;

    private UnityAction<object> ev_teleporter;
    private UnityAction<object> ev_out;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        ev_teleporter = new UnityAction<object>(Teleportation);
        ev_out = new UnityAction<object>(Out);

        EventManager.StartListening("pseudoTeleporterRed", ev_teleporter);
        EventManager.StartListening("RedOut", ev_teleporter);
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isDead") == false && controlerOn){
            movement.x = Input.GetAxisRaw("HorizontalRed");
            movement.y = Input.GetAxisRaw("VerticalRed");


            if (movement.x != 0 || movement.y != 0)
            {
                anim.SetBool("isWalking", true);
                anim.SetFloat("horizontal", movement.x);
                anim.SetFloat("vertical", movement.y);
            }
            else anim.SetBool("isWalking", false);

                if (Input.GetKeyDown(KeyCode.Keypad0) && canFire)
            {
                StartCoroutine(FireFruitCoroutine());
            }
        }

        else if(!controlerOn){
            movement.x = 0;
            movement.y = 0.5f;
            vitesse = 1.0f;
            rig.transform.rotation *= Quaternion.Euler(0, 0, 3.0f);
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
            EventManager.TriggerEvent("RedBeenHit", transform.position);
            anim.SetBool("isDead", true);
            movement = Vector2.zero;

        }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy")
        {
            EventManager.TriggerEvent("RedBeenHit", transform.position);
            anim.SetBool("isDead", true);
            movement = Vector2.zero;

        }
    }

    public IEnumerator Death()
    {
        anim.SetBool("isDead", true);
        //Instantiate(prefabNugget, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.0f);
        //StartCoroutine(fondu.GetComponent<FonduEntree>().FonduFin());
        yield return new WaitForSeconds(2.0f);
            
    }


    private IEnumerator FireFruitCoroutine()
    {
        canFire = false;

        Transform newFruit = Instantiate(prefabFruit, transform.position, Quaternion.identity);
        Fruit fruitScript = newFruit.GetComponent<Fruit>();

        Vector2 direction = Vector2.zero;
        if (movement.x != 0 || movement.y != 0)
        {
            direction = new Vector2(movement.x, movement.y);
        }
        else
        {
            direction = (m_facingRight ? Vector2.left : Vector2.right);
        }

        fruitScript.SetDirection(direction.normalized);

        yield return new WaitForSeconds(0.3f);

        canFire = true;
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
  
