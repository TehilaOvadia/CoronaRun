using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	public bool isDead = false;
	public bool isDoorOpen = false;
	public bool isHarmed = false;
	public bool enemyHasCollide;

	public Vector3 respawnPoint;
	public GameObject player;

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

			AudioManager.instance.Play("Harmed");

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

		if(other.gameObject.tag == "Platform")
        {
			player.transform.parent = other.gameObject.transform;
		}
	}

    private void OnCollisionExit2D(Collision2D other)
    {
		if (other.gameObject.tag == "Platform")
		{
			player.transform.parent = null;
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
			case "Checkpoint":
				if(respawnPoint.y < other.transform.position.y)
                {
					AudioManager.instance.Play("Checkpoint");
					respawnPoint = other.transform.position;
                }
				break;
			case "Door":
				AudioManager.instance.Play("DoorPass");

				gameLevelManager.NextLevel();
				break;
			case "Syringe":
				AudioManager.instance.Play("Collect");

				syringeManager.SetUpSyringe(true);
				break;
		}
    }
}
