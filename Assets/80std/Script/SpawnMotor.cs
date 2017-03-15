using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnMotor : MonoBehaviour {
	public float TimeBetweenWaves = 1f;
	public float Timer = 5f;
	public int waveNumber = 0;
	public GameMotor gameMotor;
	public Wave[] waves;


	private SpawnLogic spawnLogic = new SpawnLogic();
	void OnEnable(){
		spawnLogic.Timer = Timer;
		spawnLogic.TimeBetweenWaves = TimeBetweenWaves;
		spawnLogic.waveNumber = waveNumber;
		spawnLogic.waves = waves;

		spawnLogic.myMotor = this;
	}

	void Update(){
		spawnLogic.Update (Time.deltaTime);
	}

	public void StartWave(Wave wave){
		StartCoroutine(spawnLogic.SpawnWave (wave));
	}

	public void MakeEnemy(GameObject enemy){
		foreach (PlayerMotor player in GameMotor.players) {
			var spawnPoint = player.spawnPoint;
			var enemyManager = player.enemyManager;
			GameObject NewEnemy = Instantiate (enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
			NewEnemy.transform.SetParent (enemyManager.transform);
		}
	}
}

public class SpawnLogic{
	public float TimeBetweenWaves = 1f;
	public float Timer = 5f;
	public int waveNumber = 0;

	public SpawnMotor myMotor;

	public Wave[] waves;
	//public SpawnPoints[] spawnPoints;

	public void Update(float deltaTime){
		Timer -= deltaTime;

		if (TimerFinished()){
			ResetTimer();
			myMotor.StartWave(CurrentWave());
			waveNumber ++;
		}
	}

	bool TimerFinished(){
		return Timer <= 0f;
	}

	public IEnumerator SpawnWave(Wave wave){
		for (int i = 0; i < wave.numberToSpawn; i++) {
			myMotor.MakeEnemy (wave.enemyToSpawn);
			yield return new WaitForSeconds (1f / wave.spawnRate);
		}
	}

	void ResetTimer(){
		Wave wave = CurrentWave ();
		float TimeToSpawnWave = wave.numberToSpawn / wave.spawnRate;
		Timer = TimeBetweenWaves + TimeToSpawnWave;
	}

	Wave CurrentWave(){
		return waves [waveNumber];
	}
}
