using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	public MovementConfig config;
    public MovementModel model;
	public GameObject enemy;

	private Transform target;
	private int wayPointIndex = 1;
	private int waypointCount;
	private WaypointManager waypointManager;
	private float speed;
	private float closenessBeforeNextPoint;
	private float rotationSpeed;

	public void Initialize () {
		var enemyPrefabConfig = GetComponent<EnemyPrefabConfig> ();
		enemy           = enemyPrefabConfig.modelBody;
		waypointManager = enemyPrefabConfig.waypointManager;
		speed           = enemyPrefabConfig.speed;
		rotationSpeed   = enemyPrefabConfig.rotationSpeed;

		target        = waypointManager.points[wayPointIndex];
		waypointCount = waypointManager.points.Length;

		config = GetComponent<MovementConfig> ();
        model = GetComponent<MovementModel> ();
		closenessBeforeNextPoint = config.closenessBeforeNextPoint;
	}

	public void StopObject() {
		speed = 0f;
	}

	void TurnObject() {
		float rotationStep = model.NormaliseSpeed(rotationSpeed, Time.deltaTime);

		Vector3 CurrentDir = enemy.transform.forward;
		Vector3 TargetDir = model.TargetDir(target.position, enemy.transform.position);
		Vector3 TurnDir = Vector3.RotateTowards (CurrentDir, TargetDir, rotationStep, 0.0f);
		enemy.transform.rotation = Quaternion.LookRotation (TurnDir);
	}

	void MoveObject(){
		float step = model.NormaliseSpeed(speed, Time.deltaTime);
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}

	void CheckIfAtTarget(){
		if (wayPointIndex == waypointCount - 1) { return; }
		if (Vector3.Distance(transform.position, target.position) <= closenessBeforeNextPoint){
			wayPointIndex += 1;
			target = waypointManager.points[wayPointIndex];
		}
	}

	void Update () {
		TurnObject ();
		MoveObject ();
		CheckIfAtTarget ();
	}
}
