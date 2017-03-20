using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private bool gameOver;
	private bool won;

	public GameObject player1;
	private PlayerHealth player1Status;

	private EnemyManager enemyManager;

	public PlayerSpawn spawnMotor;


	void Awake (){
		gameOver = false;
		won = false;
	}

	void Start() {
		player1Status = player1.GetComponent<PlayerHealth> ();
		enemyManager = player1.GetComponentInChildren<EnemyManager> ();
	}

	void Update() {
		DeclareWinner ();
	}

	public bool IsGameOver() {
		return gameOver;
	}

	public bool IsWon() {
		return won;
	}

	public void SetGameOver(bool status) {
		gameOver = status;
	}

	bool IsWinner() {
		return spawnMotor.IsEnded () && spawnMotor.TimerFinished() && enemyManager.All ().Length == 0 && !IsGameOver();
	}

	void DeclareWinner() {
		if (IsWinner()) {
			player1Status.SetWinner (true);
			won = true;
		}
	}
}
