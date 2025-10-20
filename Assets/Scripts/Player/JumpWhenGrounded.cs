using UnityEngine;

//This script allows a GameObject to jump when the spacebar, up arrow, or 'W' key is pressed, but only if it is grounded.

public class JumpWhenGrounded : MonoBehaviour
{
    public float JumpForce = 10f; // Adjust the jump force as needed
    bool canJump;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && canJump == true)
        {
            GetComponent<Rigidbody2D>().linearVelocityY = JumpForce;
            canJump = false; // Prevent double jump until grounded again
        }
    }
    void OnCollisionEnter2D(Collision2D collision) // Detect collision with ground
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision) // Detect when leaving ground
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            canJump = false;
        }
    }
}
