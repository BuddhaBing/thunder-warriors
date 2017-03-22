using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyModel : MonoBehaviour {

	private float health;
	private float maxHealth;

	public void TakeDamage(int damage) {
		health -= damage;
	}

	public bool IsDead() {
		return health <= 0;
	}

	public float GetHealth() {
		return health;
	}

	public void SetMaxHealth(float max) {
		health = max;
		maxHealth = max;
	}

	public float HealthRatio() {
		return health / maxHealth;
	}
}
