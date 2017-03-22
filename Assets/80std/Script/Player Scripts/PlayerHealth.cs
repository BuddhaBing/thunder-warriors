using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int health;
    public int damagePerEnemy;

    public void TakeDamage(){
		health -= damagePerEnemy;
	}

	public int GetHealth(){
		return health;
	}

	public bool IsDead(){
		return health <= 0;
	}
}
