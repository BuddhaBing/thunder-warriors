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
	private GameObject genericEnemy;
	public Transform spawnPoint;
	public EnemyManager enemyManager;
	public WaypointManager wayPoints;
	private PlayerConfig owningPlayer;

	void Start() 
	{
		var spawnInfo = SpawnInfo.get;
		owningPlayer = GetComponent<PlayerConfig> ();

		waves = spawnInfo.waves;
		timer = spawnInfo.initialTimer;
		timeBetweenWaves = spawnInfo.timeBetweenWaves;
		genericEnemy = spawnInfo.genericEnemy;
	}

	void Stop(){
		StopWave ();
		stopped = true;
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

	public void MakeEnemy(EnemyConfig enemy){
		GameObject NewEnemy = Instantiate (genericEnemy, spawnPoint.transform.position, spawnPoint.transform.rotation);
		var enemyConfig = NewEnemy.GetComponent<EnemyPrefabConfig> ();
		NewEnemy.transform.SetParent (enemyManager.transform);
		enemyConfig.enemyScriptableObject = enemy;
		enemyConfig.owningPlayer = owningPlayer;
		enemyConfig.waypointManager = wayPoints;
		enemyConfig.Initialize ();
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
