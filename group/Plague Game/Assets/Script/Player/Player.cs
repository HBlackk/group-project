using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX, dirY;
    float moveSpeed = 5f;
    public static int flees;
    private HealthSystem healthSystem;

    public GameObject currenttalk = null;
    public talk current = null;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthSystem = new HealthSystem(100);
        flees = 10;
        healthSystem.Dammage(10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Find("HealthBar").localScale = new Vector3(healthSystem.GetHealth(), 1);
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirY = Input.GetAxis("Vertical") * moveSpeed;
        if (healthSystem.GetHealth() <= 0)
            Destroy(gameObject);

        if (Input.GetKey("e") && currenttalk)
            if (current.talks)
            {
                current.Talk();
            }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }
    
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Fire"))
            healthSystem.Dammage(10);
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name.Equals("Fire"))
        {
            healthSystem.Dammage(10);
        }            
        if (other.CompareTag ("interObject"))
        {
            Debug.Log(other.name);
            currenttalk = other.gameObject;
            current = currenttalk.GetComponent <talk>();
        }
    }
}