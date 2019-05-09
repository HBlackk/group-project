using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    float dirX, dirY;
    public float moveSpeed;
    public float jumpp;
    private Rigidbody2D rb;
    public static int flees;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwflea;

    public Transform groundcheck;
    public bool grounded;
    public float groundedcircle;
    public LayerMask wground;
    public GameObject fleathrow;
    public Transform throwArea;
    public GameObject currenttalk = null;
    public talk current = null;
    public GameObject flea;

    public HealthSystem healthSystem;
    public Transform pfHealthBar;
    public int startHealth;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flees = 10;

        healthSystem = new HealthSystem(startHealth);
        HealthBarScr healthBar = pfHealthBar.GetComponent<HealthBarScr>();
        healthBar.Setup(healthSystem);
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundedcircle, wground);

        //transform.Find("HealthBar").localScale = new Vector3(healthSystem.GetHealth(), 1);
        //dirX = Input.GetAxis("Horizontal") * moveSpeed;
        //dirY = Input.GetAxis("Vertical") * moveSpeed;

        /*if (Input.GetKey("e") && currenttalk)
            if (current.talks)
            {
                current.Talk();
            }*/
        if(Input.GetKey(left))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if(Input.GetKey(right))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(Input.GetKeyDown(jump) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpp);
        }

        if(Input.GetKeyDown(throwflea))
        {
            if(FleaCount.count > 0)
            {
                GameObject fleaClone = (GameObject)Instantiate(fleathrow, throwArea.position, throwArea.rotation);
                fleaClone.transform.localScale = transform.localScale;
                FleaCount.count = FleaCount.count - 1;
            }            
        }

        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-0.35f, 0.28f, 1);
        }
        else if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.35f, 0.28f, 1);
        }
    }

    void FixedUpdate()
    {
        //rb.velocity = new Vector2(dirX, dirY);
    }
    
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Fire"))
            healthSystem.Dammage(10);
    }*/

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.tag.Equals("Projectile"))
        {
            healthSystem.Dammage(5);
        }
  
        if (other.CompareTag ("interObject"))
        {
            Debug.Log(other.name);
            currenttalk = other.gameObject;
            current = currenttalk.GetComponent <talk>();
        }

        if (other.tag.Equals("Flea"))
        {
            FleaCount.count += 10;
            Destroy(other.gameObject);
        }
    }
}