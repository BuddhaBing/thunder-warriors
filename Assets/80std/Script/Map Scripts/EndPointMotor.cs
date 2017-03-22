using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointMotor : MonoBehaviour {

	public GameObject player;
	private EndPointAudio sfx;

	void Awake() {
		sfx = this.transform.GetComponent<EndPointAudio>();
	}

	void OnTriggerEnter(Collider collider){
		EnemyLeaked (collider.gameObject);
	}

	public void EnemyLeaked(GameObject Enemy){
		if (Enemy.tag != "Enemy") {return;}
		if (sfx) {sfx.PlayBreachAudio();}
		GameObject.Destroy(Enemy);
		DamagePlayer (player);
	}

	void DamagePlayer(GameObject player) {
		player.GetComponent<PlayerState> ().TakeDamage ();
	}
}
