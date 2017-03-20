using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	public int health;
	public int damagePerEnemy;

	private GameManager gameMotor;
	private bool winner = false;

	void Start(){
		gameMotor = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	public void TakeDamage(){
		health -= damagePerEnemy;
		Status ();
	}

	public int GetHealth(){
		return health;
	}

	bool IsGameOver(){
		return health <= 0;
	}

	public void SetWinner(bool status) {
		winner = status;
		Status ();
	}

	void Status() {
//		if (winner){
//			UpdateLivesUi("Level Complete");
//		} else if (IsGameOver ()) {
//			UpdateLivesUi ("Game Over");
//			gameMotor.SetGameOver (true);
//		} else {
//			UpdateLivesUi ("Lives:" + lives);
//		}
	}
		

}
