using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float travelSpeed = 10f;
    [SerializeField]
    private int lifespan = 2;
    [SerializeField]
    private LayerMask whatShouldHit;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(travelSpeed, 0);
        Destroy(gameObject, lifespan); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (whatShouldHit == (whatShouldHit | (1 << collision.gameObject.layer))) {
            Destroy(gameObject);
            if (!collision.gameObject.tag.Equals("Indestructible"))
            {
                Destroy(collision.gameObject);
            }
        }
    }




}
