using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnMotor : MonoBehaviour {
	public float TimeBetweenWaves = 1f;
	public float Timer = 5f;
	public int waveNumber = 0;
	public Wave[] waves;


	void Update(){
		MyUpdate (Time.deltaTime);
	}

	public void MyUpdate(float deltaTime){
		Timer -= deltaTime;
		if (TimerFinished()){
			ResetTimer();
			StartWave(CurrentWave());
			waveNumber ++;
		}
	}
	
	public void StartWave(Wave wave){
		StartCoroutine(SpawnWave (wave));
	}
	
	public IEnumerator SpawnWave(Wave wave){
		for (int i = 0; i < wave.numberToSpawn; i++) {
			MakeEnemy (wave.enemyToSpawn);
			yield return new WaitForSeconds (1f / wave.spawnRate);
		}
	}
	
	public void MakeEnemy(GameObject enemy){
		foreach (PlayerMotor player in GameMotor.players) {
			var spawnPoint = player.spawnPoint;
			var enemyManager = player.enemyManager;
			GameObject NewEnemy = Instantiate (enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
			NewEnemy.transform.SetParent (enemyManager.transform);
		}
	}
	
	void ResetTimer(){
		Wave wave = CurrentWave ();
		float TimeToSpawnWave = wave.numberToSpawn / wave.spawnRate;
		Timer = TimeBetweenWaves + TimeToSpawnWave;
	}
	
	bool TimerFinished(){
		return Timer <= 0f;
	}

	Wave CurrentWave(){
		return waves [waveNumber];
	}
}
