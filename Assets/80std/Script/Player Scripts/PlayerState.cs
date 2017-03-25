using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

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

	void Update() {
		CheckWon ();
		CheckLost ();
	}

    public void TakeDamage()
    {
        playerHealth.TakeDamage();
    }

	public int GetState(){
		return winState;
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
