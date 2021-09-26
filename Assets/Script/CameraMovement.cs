using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;

    private Vector3 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

        if(player.transform.localScale.y > 0f)
        {
            playerPosition = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);
        }
        else
        {
            playerPosition = new Vector3(transform.position.x, player.transform.position.y - offset, transform.position.z);
        }

        //Make the camera move smooth
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

        //Limit the camera in y movement
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(player.transform.position.y, -2, 190),transform.position.z);
    }
}
