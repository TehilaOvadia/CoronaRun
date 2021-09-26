using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Ground")
    //    {
    //        player.GetComponent<PlayerMovement>().isGrounded = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    player.GetComponent<PlayerMovement>().isGrounded = false;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            player.GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.GetComponent<PlayerMovement>().isGrounded = false;
    }
}
