using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    private string indoorSceneName = "InsideHouseScene";
 

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate ()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check the collided object by tag, name, or layer, etc.
        // For example, checking by tag:
        if(collision.gameObject.CompareTag("house"))
        {
            Debug.Log("Collided with the house!");
            // Here you can add code to handle the collision appropriately,
            // like stopping the player's movement, taking damage, etc.
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered the trigger is tagged "Indoor1"
        if (other.CompareTag("Indoor1"))
        {
            // Make sure the scene you want to load is added to the build settings.
            SceneManager.LoadScene(indoorSceneName);
        }
    }
}

