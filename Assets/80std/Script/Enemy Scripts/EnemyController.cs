using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private EnemyPrefabConfig config;
	private EnemyModel model;
	private EnemyView view;
	private bool dead = false;

	void Start () {
		config = GetComponent<EnemyPrefabConfig> ();
		model = config.enemyModel;
		view = config.enemyView;

		model.SetMaxHealth (config.maxHealth);
	}


	public void Damage(int damage)
	{
		if (dead) return;
		model.TakeDamage (damage);
		if (model.IsDead ()) {
			dead = true;
			view.DeathSequence ();
		} else {
			view.HitSequence();
		}
	}
}
