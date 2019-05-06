using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX, dirY;
    float moveSpeed = 5f;
    public static int flees;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HealthSystem healthSystem = new HealthSystem(100);
        flees = 10;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirY = Input.GetAxis("Vertical") * moveSpeed;

        if (healthAmount <= 0)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, dirY);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Fire"))
            healthAmount -= 0.1f;
    }

}