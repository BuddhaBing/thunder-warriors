using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	private Transform target;
	private int WayPointIndex = 1;
	private float ClosenessBeforeNextPoint = 0.1f;

	public float Speed = 4f;
	public float RotationSpeed = 10f;

	void Start () {
		target = WaypointManager.points[WayPointIndex];

	}
		
	void TurnObject() {
		float rotationStep = RotationSpeed * Time.deltaTime;

		Vector3 CurrentDir = transform.forward;
		Vector3 TargetDir = target.position - transform.position;
		Vector3 TurnDir = Vector3.RotateTowards (CurrentDir, TargetDir, rotationStep, 0.0f);

		transform.rotation = Quaternion.LookRotation (TurnDir);
	}

	void MoveObject(){
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}

	void CheckIfAtTarget(){
		if (Vector3.Distance(transform.position, target.position) <= ClosenessBeforeNextPoint){
			WayPointIndex += 1;
			target = WaypointManager.points[WayPointIndex];
		}
	}
		
	void Update () {
		TurnObject ();
		MoveObject ();
		CheckIfAtTarget ();
	}
}
