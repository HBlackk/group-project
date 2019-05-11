using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed;
    public float stop_dist;
    public float retreat_dist;

    private float shot_time;
    public float start_shot_time;

    public Transform player;
    public GameObject projectile;

    public HealthSystem healthSystem;
    public Transform pfHealthBar;
    public int startHealth;

    private Rigidbody2D rb;
    public float distance;
    private bool movingRight = true;
    public Transform groundDetect;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        healthSystem = new HealthSystem(startHealth);
        HealthBarScr healthBar = pfHealthBar.GetComponent<HealthBarScr>();
        healthBar.Setup(healthSystem);

        shot_time = start_shot_time;
    }

    void Update()
    {

        /*if (Vector2.Distance(transform.position, player.position) > stop_dist)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stop_dist && (Vector2.Distance(transform.position, player.position) > retreat_dist))
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreat_dist)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), -speed * Time.deltaTime);
        }*/
        int Layermask = LayerMask.GetMask("Ground");
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D ground = Physics2D.Raycast(groundDetect.position, Vector2.down, 0, Layermask);

        if (ground.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                movingRight = true;
            }
        }
         


        if (shot_time <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shot_time = start_shot_time;
        }
        else
        {
            shot_time -= Time.deltaTime;
        }

        if (healthSystem.GetHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Projectile"))
        {
            healthSystem.Dammage(1);
        }
        if (other.tag.Equals("thrownflea"))
        {
            System.Random rnd = new System.Random();
            int x = rnd.Next(1, 3);
            if (x == 1)
            {
                healthSystem.Dammage(20);
            }
            else if (x == 2)
            {
                healthSystem.Dammage(40);
            }
            else
            {
                healthSystem.Dammage(80);
            }
        }
        if (other.tag.Equals("Player"))
        {
            healthSystem.Dammage(12);
        }
    }
}



	//stopping dist should be 20
	//retreat distance should be 10

	//start_shot_time == 1 in window

	//create prefab folder, put sprite in then prefab in window.
