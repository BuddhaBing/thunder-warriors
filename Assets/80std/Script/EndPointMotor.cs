using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointMotor : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		EnemyLeaked (collider.gameObject);
	}

	public void EnemyLeaked(GameObject Enemy){
		if (Enemy.tag != "Enemy") {return;}
		GameObject.Destroy(Enemy);
		//Hurt player
	}
}
