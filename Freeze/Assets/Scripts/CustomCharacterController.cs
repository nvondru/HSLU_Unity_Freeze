using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private int extraJumps;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float freezeMultiplikator = 0.1f;


    private int jumpCount = 0;  
    private bool spaceTriggered = false;

    private Rigidbody2D rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceTriggered = true;
        }
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetButton("Fire1"))
        {
            rb.velocity *= freezeMultiplikator;
        }
    }

    private void FixedUpdate()
    {
        if (spaceTriggered && CanJump())
        {
            if (rb.velocity.y >= 0)
            {
                rb.velocity += new Vector2(rb.velocity.x, jumpForce);

            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }
            jumpCount++;

            Debug.Log(rb.velocity);
        }

        spaceTriggered = false;
    }


    private bool CanJump()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround))
        {
            jumpCount = 0;
            return true;
        }else if(jumpCount <= extraJumps)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
