using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	public bool isDead = false;
	public bool isDoorOpen = false;
	public bool isHarmed = false;
	public bool enemyHasCollide;

	public Vector3 respawnPoint;

	LevelManager gameLevelManager;
	SyringeScript syringeManager;

    private void Awake()
    {
		gameLevelManager = FindObjectOfType<LevelManager>();
		syringeManager = FindObjectOfType<SyringeScript>();
	}

    private void Start()
    {
		respawnPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
		if ((other.gameObject.tag == "Enemy") && !enemyHasCollide && !isDoorOpen)
		{
			enemyHasCollide = true;

			if (gameLevelManager.hasSyringe)
            {
				syringeManager.SetUpSyringe(false);
				gameLevelManager.GetHarmed();
			}
            else
            {
				if (gameLevelManager.healthAmount > 1)
				{
					gameLevelManager.healthAmount--;
					gameLevelManager.SaveGameData();

					gameLevelManager.Respawn();
				}
				else if (gameLevelManager.healthAmount <= 1)
				{
					gameLevelManager.GameOver();
				}
            }
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
			case "Checkpoint":
				respawnPoint = other.transform.position;
				break;
			case "Door":
				gameLevelManager.NextLevel();
				break;
			case "Syringe":
				syringeManager.SetUpSyringe(true);
				break;
		}
    }
}
