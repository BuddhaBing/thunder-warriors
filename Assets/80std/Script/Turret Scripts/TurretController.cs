using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

	private TurretConfig self;

	private TurretModel model;
	private TurretView view;
	private TurretTargeting targeting;

	void Start () {
		self = GetComponent<TurretConfig>();
		self.owner = transform.parent.parent.GetComponentInParent<PlayerConfig>();
		model = self.model;
		targeting = self.targeting;
		view = self.view;
		InvokeRepeating ("UpdateTarget", self.updateRate, self.updateRate);
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
			if (!enemy || enemy.GetComponent<EnemyModel> ().IsDead()) {
				targeting.ResetTarget ();
				continue;
			}
			targeting.FindNearestEnemy (enemy, self.range);
			targeting.SelectEnemy (self.range);
		}
		targeting.ResetDistance ();
	}

}
