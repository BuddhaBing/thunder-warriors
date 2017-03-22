using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	private bool winner = false;

	private PlayerHealth playerHealth;
	private PlayerSpawn playerSpawn;
	private PlayerUI playerUI;
	private EnemyManager playerEnemies;

	private int winState = -1;

	void Start(){
		var playerConfig = GetComponent<PlayerConfig> ();

		playerHealth = playerConfig.health;
		playerSpawn = playerConfig.spawn;
		playerUI = playerConfig.UI;
		playerEnemies = playerConfig.enemyManager;
	}

    public void TakeDamage()
    {
        playerHealth.TakeDamage();
        UpDateStatus();
    }

	public int GetState(){
		return winState;
	}

	public void UpDateStatus(){
		CheckWon ();
		CheckLost ();
	}
		
	void CheckWon(){
		if (playerSpawn.IsEnded () && playerEnemies.IsEmpty ()) {
			winState = 0;
		}
	}

	void CheckLost(){
		if (playerHealth.IsDead()) {
			winState = 1;
		}
	}
}
