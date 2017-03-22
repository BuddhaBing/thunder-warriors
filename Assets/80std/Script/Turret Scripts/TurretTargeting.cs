using UnityEngine;
using System.Collections;

public class TurretTargeting : MonoBehaviour
{
	private TurretConfig self;

	private Transform target;
	private float shortestDistance = Mathf.Infinity;
	private GameObject nearestEnemy;

	void Start () {
		self = GetComponent<TurretConfig>();
	}
	
	public void FindNearestEnemy(GameObject enemy, float range) {
		if (DistanceToEnemy(enemy) < shortestDistance) {
			shortestDistance = DistanceToEnemy(enemy);
			nearestEnemy = enemy;
		}
	}

	public void SelectEnemy(float range) {
		if (nearestEnemy && shortestDistance <= range) {
			target = nearestEnemy.transform;
		}
	}

	public void ResetTarget() {
		shortestDistance = Mathf.Infinity;
		target = null;
		nearestEnemy = null;
	}

	float DistanceToEnemy(GameObject enemy) {
		return Vector3.Distance (transform.position, enemy.transform.position);
	}

	public Vector3 AngleToTarget() {
		Quaternion lookRotation = Quaternion.LookRotation (target.position - transform.position);
		return Quaternion.Lerp(self.partToRotate.rotation, lookRotation, Time.deltaTime * self.turnSpeed).eulerAngles;
	}

	public Transform CurrentTarget() {
		return target;
	}

}

