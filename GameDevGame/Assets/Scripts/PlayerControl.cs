using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    void Update()
    {
        //player
        GameObject player = GameObject.Find("Player");

        //player presses left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            player.transform.position += Vector3.left*0.5f;
        }
        //player presses up
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            player.transform.position += Vector3.forward * 0.5f;
        }
        //player presses right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            player.transform.position += Vector3.right * 0.5f;
        }
        //player presses down
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            player.transform.position += Vector3.back * 0.5f;
        }
    }
}
