using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public string EnemyTag = "Enemy";

	private float UpdateRate = 1f;

	private GameObject[] AllEnemies;

	public GameObject[] All(){
		
		return AllEnemies;
	}

	void Start	(){
		InvokeRepeating ("UpdateAllEnemies",0f,UpdateRate);
	}

	void UpdateAllEnemies(){
		AllEnemies = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			AllEnemies [i] = transform.GetChild (i).gameObject;
		}
	}
}
