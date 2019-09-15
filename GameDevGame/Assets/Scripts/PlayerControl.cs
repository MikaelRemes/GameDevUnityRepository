using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float jumpPower;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //player
        GameObject player = GameObject.Find("Player");

        //player presses left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            player.transform.position += Vector3.left* speed;
        }
        //player presses up
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            player.transform.position += Vector3.forward * speed;
        }
        //player presses right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            player.transform.position += Vector3.right * speed;
        }
        //player presses down
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
                player.transform.position += Vector3.back * speed;
        }
        //player presses space
        if (Input.GetKey(KeyCode.Space))
        {
            //check if player is on the ground
            if (Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.1f))
            {
                //check if player already has y velocity
                if (rb.velocity.y==0) {
                    rb.AddForce(transform.up * jumpPower);
                }
            }
        }
        //remove front, back, left and right velocities
        rb.velocity = new Vector3(0,rb.velocity.y,0);
    }
}
