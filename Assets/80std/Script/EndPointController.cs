// Probably better to add collision boxes and check them than this mess.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour {

	public float killZoneSize = 0.9f;
	public float checkRate = 0.1f;

	public EnemyManager MyEnemyManager;

	void Start(){
		InvokeRepeating ("CheckIfInRange",0f,checkRate);
	}

	void KillZoneEntered(GameObject enemy){
		Destroy (enemy);
	}

	void CheckIfInRange(){
		GameObject[] enemies = MyEnemyManager.All ();
		if (enemies == null){return;}
		foreach (GameObject enemy in enemies) {
			if(enemy == null){continue;}
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < killZoneSize) {
				KillZoneEntered (enemy);
			}
		}
		
	}

}
