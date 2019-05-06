using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float speed;
	public float stop_dist;
	public float retreat_dist;
	
	private float shot_time;
	public float start_shot_time;
	
	public Transform player;
	public GameObject projectile;
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
		shot_time = start_shot_time;
		}
		
		void Update () {
		
			if(Vector2.Distance(transform.position, player.position) > stop_dist)
			{
				transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
			}	
			else if (Vector2.Distance(transform.position, player.position) < stop_dist && (Vector2.Distance(transform.position, player.position) > retreat_dist))
			{
				transform.position = this.transform.position;
			}	
			else if (Vector2.Distance(transform.position, player.position) < retreat_dist)
			{
				transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
			}	
			
			if(shot_time <= 0)
			{
				Instantiate(projectile, transform.position, Quaternion.identity);
				shot_time = start_shot_time;
			}
			else
			{
				shot_time -= Time.deltaTime;
			}
			
		}
}	
	
	
	
	//stopping dist should be 20
	//retreat distance should be 10
	
	//start_shot_time == 1 in window
	
	//create prefab folder, put sprite in then prefab in window.
	
