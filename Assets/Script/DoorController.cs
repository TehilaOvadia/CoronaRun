using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private ParticleSystem doorParticalRenderer;
    public bool doorReached;

    void Start()
    {
        doorParticalRenderer = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var main = doorParticalRenderer.main;
            main.startSize = 10;
            doorReached = true;
        }
    }
}
