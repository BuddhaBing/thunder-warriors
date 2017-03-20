using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
	public bool stopped = false;

	private float timeBetweenWaves = 1f;
	private float timer = 5f;
	private int waveNumber = 0;
	private Coroutine waveSpawner = null;
	private Wave[] waves;
	private Transform spawnPoint;
	private EnemyManager enemyManager;
	private WaypointManager wayPoints;
	private PlayerConfig owningPlayer;

	void Start() 
	{
		var spawnInfo = SpawnInfo.get;
		owningPlayer = GetComponentInParent<PlayerConfig> ();

		waves = spawnInfo.waves;
		timer = spawnInfo.initialTimer;
		timeBetweenWaves = spawnInfo.timeBetweenWaves;

		spawnPoint   = owningPlayer.spawnPoint;		
		enemyManager = owningPlayer.enemyManager;
		wayPoints    = owningPlayer.waypoints;
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
		timer -= deltaTime;
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
			yield return new WaitForSeconds (1f / wave.spawnRate);
		}
	}

	public void MakeEnemy(GameObject enemy){
		GameObject NewEnemy = Instantiate (enemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
		NewEnemy.transform.SetParent (enemyManager.transform);
		NewEnemy.GetComponent<EnemyHealth> ().OwningPlayer = owningPlayer;
		NewEnemy.GetComponent<EnemyMovementController> ().waypointManager = wayPoints;
	}

	void ResetTimer(){
		Wave wave = CurrentWave ();
		float TimeToSpawnWave = wave.numberToSpawn / wave.spawnRate;
		timer = timeBetweenWaves + TimeToSpawnWave;
	}

	void NextWave() {
		waveNumber++;
	}

	public bool TimerFinished(){
		return timer <= 0f;
	}

	void StopWave() {
		StopCoroutine(waveSpawner);
	}

	public bool IsEnded() {
		return waveNumber > (waves.Length - 1);
	}

	Wave CurrentWave(){
		return waves [waveNumber];
	}
}
