using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGravity : MonoBehaviour
{
	public float gravitychange = 1f;
	protected Vector2 velocity;
	protected Rigidbody2D rb2d;
	
	void Enable()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void FixedUpdate()
	{
		velocity = velocity + (gravitychange * Physics2D.gravity * Time.deltaTime);
		Vector2 deltaposition = velocity * Time.deltaTime;
		Vector2 move = Vector2.up * deltaposition.y;
		Movement(move);
	}	
	
	void Movement(Vector2 move)
	{
		rb2d.position = rb2d.position + move;
	}	
}
