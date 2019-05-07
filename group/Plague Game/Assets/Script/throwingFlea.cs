using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwingFlea : MonoBehaviour
{
    public GameObject flea_effect;
    public float fleaSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(fleaSpeed * transform.localScale.x , 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(flea_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
