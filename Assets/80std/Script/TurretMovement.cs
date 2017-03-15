using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour {

	private Transform target;
	private float shortestDistance;
	private GameObject nearestEnemy;

	[Header("Attributes")]

	public float range = 15f;

	[Header("Unity Setup Fields")]

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	public EnemyManager enemyManager;

	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, enemyManager.UpdateRate);
	}

	void UpdateTarget() {
		shortestDistance = Mathf.Infinity;
		nearestEnemy = null;

		foreach(GameObject enemy in enemyManager.All()) {
			if (DistanceToEnemy(enemy) < shortestDistance) {
				shortestDistance = DistanceToEnemy(enemy);
				nearestEnemy = enemy;
			}
		}
		SelectEnemy ();
	}

	float DistanceToEnemy(GameObject enemy) {
		return Vector3.Distance (transform.position, enemy.transform.position);
	}

	void SelectEnemy() {
		if (nearestEnemy && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} else {
			target = null;
		}
	}
	
	void Update () {
		if (!target)
			return;
		LockOn();
	}

	void LockOn() {
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

}
