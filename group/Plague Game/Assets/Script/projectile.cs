using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class projectile : MonoBehaviour {
	
	public float speed;
	
	private Transform player;
	private Vector2 target;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
		target = new Vector2(player.position.x, player.position.y);
	}	
	
	
	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
		
		if(transform.position.x == target.x && transform.position.y == target.y)
		{
			DestroyProjectile();
		}	
	}	
	
	void DestroyProjectile()
	{
		Destroy(gameObject);
	}	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			DestroyProjectile();
		}else if (!other.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }	
}	

//player needs rigidbody2d and collider2d
//add circle collider 2d to projectile
//is trigger
//speed == 20