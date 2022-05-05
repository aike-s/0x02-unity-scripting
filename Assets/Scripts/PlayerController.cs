using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1100f;
    public Rigidbody player;
    private int score = 0;
    public int health = 5;

    // Update is called once per frame

    void Update ()
    {
        // if player dies
        if (health == 0)
        {
            Debug.Log("Game over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {

        // Press up
        if (Input.GetKey("w"))
        {
            player.AddForce(0, 0, speed * Time.deltaTime);
        }
        // Press down
        if (Input.GetKey("s"))
        {
            player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        // Press left
        if (Input.GetKey("a"))
        {
            player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        // Press right
        if (Input.GetKey("d"))
        {
            player.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // If the player touches a coin
        if (other.tag == "Pickup")
        {
            score++;
            Destroy(other.gameObject);
            Debug.Log("Score: " + score);
        }

        // If player touches a trap
        if (other.tag == "Trap")
        {
            health--;
            Debug.Log("Health: " + health);
        }

        // If player wins!
        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
}
