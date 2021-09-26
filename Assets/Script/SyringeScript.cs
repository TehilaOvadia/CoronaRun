using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeScript : MonoBehaviour
{
    public float speed = 0.7f;
    public GameObject syringe;

    LevelManager gameLevelManager;

    private Vector3 syringePosition;

    private void Awake()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    void Start()
    {
        syringePosition = transform.position;

        syringe.SetActive(gameLevelManager.hasSyringe);
    }

    void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) + syringePosition.y;
        transform.position = new Vector3(syringePosition.x, y, 0);
    }

    public void SetUpSyringe(bool hasSyringe)
    {
        syringe.SetActive(hasSyringe);
        gameLevelManager.hasSyringe = hasSyringe;

        //Save game info
        gameLevelManager.SaveGameData();

        if (hasSyringe)
        {
            Destroy(gameObject);
        }
    }
}
