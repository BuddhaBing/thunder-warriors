using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	private GameObject[] AllEnemies;

	public float UpdateRate = 0.5f;
	private bool started = false;
	public GameObject[] All(){
		
		return AllEnemies;
	}

	void Start	(){
		InvokeRepeating ("UpdateAllEnemies",0f, UpdateRate);
	}

	void UpdateAllEnemies(){
		AllEnemies = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			started = true;
			AllEnemies [i] = transform.GetChild (i).gameObject;
		}
	}

	public bool IsEmpty(){
		if (!started) return false;
		return AllEnemies.Length == 0;
	}
}
	