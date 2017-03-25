using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private TurretConfig self;

	private TurretModel model;
	private TurretView view;
	private TurretTargeting targeting;

	void Start () {
		self = GetComponent<TurretConfig>();
		model = self.model;
		targeting = self.targeting;
		view = self.view;
		InvokeRepeating ("UpdateTarget", 0.5f, self.updateRate);
	}

	void Update () {
		if (!targeting.CurrentTarget()) return;
		view.LockOn(self.targeting.AngleToTarget ());
		Shoot ();
	}

	void Shoot() {
		if (model.IsTimeToFire()) {
			view.FireBullet (targeting.CurrentTarget());
			model.ResetTimer (self.fireRate);
		}
		model.DecreaseTimer ();
	}

	void UpdateTarget() {
		foreach(GameObject enemy in self.enemies.All()) {
//			if (!enemy || enemy.GetComponent<EnemyModel> ().IsDead())
			if (!enemy || enemy.GetComponent<EnemyHealth> ().health <= 0) {
				targeting.ResetTarget ();
				continue;
			}
			targeting.FindNearestEnemy (enemy, self.range);
			targeting.SelectEnemy (self.range);
		}
	}

}
