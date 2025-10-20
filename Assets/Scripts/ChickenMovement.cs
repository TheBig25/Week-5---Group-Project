using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    // Public variables to control movement speed and flap force
    // Public allows you to adjust these values in the Unity Inspector
    public float HorizontalSpeed = 5f;
    public float FlapForce = 5f;
    bool canJump;
    public int maxJumps = 3; // 1 on ground + 2 in air
    private int jumpsLeft; // Tracks remaining jumps


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Prevents Chicken from rotating 
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        jumpsLeft = maxJumps; // Initialise jumps left

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().linearVelocityX = -HorizontalSpeed;
            GetComponent<SpriteRenderer>().flipX = true; // Flip sprite to face left
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().linearVelocityX = +HorizontalSpeed;
            GetComponent<SpriteRenderer>().flipX = false; // Flip sprite to face right
        }

        Jump();


        void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && jumpsLeft > 0)
            {
                GetComponent<Rigidbody2D>().linearVelocityY = FlapForce;
                jumpsLeft--;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) // Detect collision with ground
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpsLeft = maxJumps;
        }
        
        else if (collision.gameObject.CompareTag("trampoline"))
        {
            GetComponent<Rigidbody2D>().linearVelocityY = FlapForce * 3; //makes the chicken jump higher when hitting the trampoline
        }
    }

    

}