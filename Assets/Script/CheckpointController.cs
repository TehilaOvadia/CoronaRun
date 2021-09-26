using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    private ParticleSystem checkpointParticalRenderer;
    //public Color reachedColor;
    public Gradient reachedColor;
    public bool checkpointReached;

    void Start()
    {
        checkpointParticalRenderer = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            var colorOverLifetime = checkpointParticalRenderer.colorOverLifetime;
            colorOverLifetime.color = reachedColor;
            checkpointReached = true;
        }
    }
}
