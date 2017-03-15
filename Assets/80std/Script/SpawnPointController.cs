using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController: MonoBehaviour {
	public float TimeBetweenWaves = 1f;
	public float Timer = 5f;

	public EnemyManager MyEnemyManager;

	public Wave[] waves;

	public int waveNumber = 0;

	void Update () {
		UpdateTimer ();
		if (TimerFinished()){
			ResetTimer();
			StartWave();
		}
			
	}

	IEnumerator spawnWave(Wave wave){
		for (int i = 0; i < wave.numberToSpawn; i++) {
			spawnEnemy (wave.enemyToSpawn);
			yield return new WaitForSeconds (1f / wave.spawnRate);
		}
	}
	
	void spawnEnemy(GameObject enemy){
		
		GameObject NewEnemy = Instantiate (enemy, transform.position, transform.rotation);
		NewEnemy.transform.SetParent (MyEnemyManager.transform);
	}
	
	bool TimerFinished(){
		return Timer <= 0f;
	}

	void StartWave(){
		StartCoroutine(spawnWave (CurrentWave()));
	}

	void ResetTimer(){
		Wave wave = CurrentWave ();
		float TimeToSpawnWave = wave.numberToSpawn / wave.spawnRate;
		Timer = TimeBetweenWaves + TimeToSpawnWave;
	}
		
	void UpdateTimer (){
		Timer -= Time.deltaTime;
	}

	Wave CurrentWave(){
		return waves [waveNumber];
	}


}
