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
    private string indoorSceneName ;
    
    private void Start()
    {
        // Ensuring that the player is moved to the correct position when the scene starts
        SceneTransition.SpawnPlayerAtPosition(this.gameObject);
    }

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
        if (other.CompareTag("Indoor1"))
        {
            SceneManager.LoadScene("InsideHouseScene");
        }
        else if (other.CompareTag("indoor2"))
        {
            SceneManager.LoadScene("InsideHouseScene2");
        }
        else if (other.CompareTag("Exit"))
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (other.CompareTag("indoor3"))
        {
            SceneManager.LoadScene("InsideHouseScene3");
        }
        else if (other.CompareTag("indoor4"))
        {
            SceneManager.LoadScene("InsideHouseScene4");
        }
        else if (other.CompareTag("indoor5"))
        {
            SceneManager.LoadScene("InsideHouseScene5");
        }
        else if (other.CompareTag("doorgame"))
        {
            SceneManager.LoadScene("gamecenter");
        }
        
    }

}

