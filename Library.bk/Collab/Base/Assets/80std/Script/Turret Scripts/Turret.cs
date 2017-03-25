using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private TurretConfig self;

	private TurretModel model;
	private TurretView view;

	void Start () {
		self = GetComponent<TurretConfig>();
		model = self.model;
		view = self.view;
		InvokeRepeating ("UpdateTarget", 0.5f, self.updateRate);
	}

	void Update () {
		if (!model.CurrentTarget()) return;
		view.LockOn();
		Shoot ();
	}

	void Shoot() {
		if (model.IsTimeToFire()) {
			view.FireBullet (model.CurrentTarget());
			model.ResetTimer (self.fireRate);
		}
		model.DecreaseTimer ();
	}

	void UpdateTarget() {
		foreach(GameObject enemy in self.enemies.All()) {
//			if (!enemy || enemy.GetComponent<EnemyModel> ().IsDead())
			if (!enemy || enemy.GetComponent<EnemyHealth> ().health <= 0) {
				model.ResetTarget ();
				continue;
			}
			model.FindNearestEnemy (enemy, self.range);
			model.SelectEnemy (self.range);
		}
	}

}
