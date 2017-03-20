using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;
	private float shortestDistance;
	private GameObject nearestEnemy;
	public GameObject owner;

	[Header("Attributes")]

	public float range = 3f;
	public float turnSpeed = 10f;
	public float fireRate = 2f;
	public float updateRate = 0.5f;
	private float fireCountdown = 0f;

	[Header("Unity Setup Fields")]

	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public Transform[] firepoints;
	public EnemyManager enemyManager;
	public GameObject bulletPrefab;

	void Start () {
		InvokeRepeating ("UpdateTarget", 0.5f, updateRate);
	}

	public void SetOwner(GameObject player) {
		owner = player;
	}

	public GameObject Owner() {
		return owner;
	}

	void UpdateTarget() {
		shortestDistance = Mathf.Infinity;
		nearestEnemy = null;
		foreach(GameObject enemy in enemyManager.All()) {
			if (!enemy)
				continue;
			if (enemy.GetComponent<EnemyHealth> ().health <= 0)
				continue;
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
		Shoot ();
	}

	void LockOn() {
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}

	void Shoot() {
		if (fireCountdown <= 0f) {
			FireBullet ();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;
	}

	void FireBullet() {
		foreach (Transform firepoint in firepoints) {
			GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, firepoint.position, firepoint.rotation);
			Bullet bullet = bulletGO.GetComponent<Bullet> ();
			if (bullet != null)
				bullet.Seek (target);
		}
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

}
