using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnMotor : MonoBehaviour {
	public Players Players;

	public float TimeBetweenWaves = 1f;
	public float Timer = 5f;
	public int waveNumber = 0;
	public Wave[] waves;
	private int totalEmenies;
	public bool stopped = false;

	private Coroutine waveSpawner = null;

	void Start() {
		totalEmenies = 0;
	}

	void Stop(){
		StopWave ();
		stopped = true;
	}
		
	void Update(){
		MyUpdate (Time.deltaTime);
	}

	public void MyUpdate(float deltaTime){
		if (stopped) {return;}
		Timer -= deltaTime;
		if (TimerFinished()){
			if(!IsEnded()) { 
				ResetTimer();
				StartWave (CurrentWave ());
			}
			NextWave ();
		}
	}
	
	public void StartWave(Wave wave){
		if (!IsEnded ()) {
			waveSpawner = StartCoroutine (SpawnWave (wave));
		}
	}
	
	public IEnumerator SpawnWave(Wave wave){
		for (int i = 0; i < wave.numberToSpawn; i++) {
			MakeEnemy (wave.enemyToSpawn);
			totalEmenies++;
			yield return new WaitForSeconds (1f / wave.spawnRate);
		}
	}
	
	public void MakeEnemy(GameObject enemy){
		foreach (PlayerConfig player in Players.All) {
			var spawnPoint = player.spawnPoint;
			var enemyManager = player.enemyManager;
			GameObject NewEnemy = Instantiate (enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
			NewEnemy.transform.SetParent (enemyManager.transform);
			NewEnemy.GetComponent<EnemyMovementController> ().waypointManager = player.waypoints;
		}
	}
	
	void ResetTimer(){
		Wave wave = CurrentWave ();
		float TimeToSpawnWave = wave.numberToSpawn / wave.spawnRate;
		Timer = TimeBetweenWaves + TimeToSpawnWave;
	}

	void NextWave() {
		waveNumber++;
	}
	
	public bool TimerFinished(){
		return Timer <= 0f;
	}

	void StopWave() {
		StopCoroutine(waveSpawner);
	}

	public int TotalEnemies() {
		return totalEmenies;
	}

	public bool IsEnded() {
		return waveNumber > (waves.Length - 1);
	}

	Wave CurrentWave(){
		return waves [waveNumber];
	}
}
