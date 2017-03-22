using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnInfo : MonoBehaviour {
	public float timeBetweenWaves = 1f;
	public float initialTimer = 5f;
	public int waveNumber = 0;
	public Wave[] waves;
	public GameObject genericEnemy;
	static public SpawnInfo get;
	void Awake(){
		get = this;
	}
}
