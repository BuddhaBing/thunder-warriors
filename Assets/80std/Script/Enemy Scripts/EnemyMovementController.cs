using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

	private Transform target;
	private int WayPointIndex = 1;
	private int waypointCount;
	private float ClosenessBeforeNextPoint = 0.1f;

	public GameObject modelBody;
	public float Speed = 4f;
	public float RotationSpeed = 10f;
	public WaypointManager waypointManager;

	void Start () {
		target = waypointManager.points[WayPointIndex];
		waypointCount = waypointManager.points.Length;
	}

	void TurnObject() {
		float rotationStep = RotationSpeed * Time.deltaTime;

		Vector3 CurrentDir = modelBody.transform.forward;
		Vector3 TargetDir = target.position - modelBody.transform.position;
		Vector3 TurnDir = Vector3.RotateTowards (CurrentDir, TargetDir, rotationStep, 0.0f);
		modelBody.transform.rotation = Quaternion.LookRotation (TurnDir);
	}

	void MoveObject(){
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}

	void CheckIfAtTarget(){
		if (WayPointIndex == waypointCount - 1) { return; }
		if (Vector3.Distance(transform.position, target.position) <= ClosenessBeforeNextPoint){
			WayPointIndex += 1;
			target = waypointManager.points[WayPointIndex];
		}
	}

	void Update () {
		TurnObject ();
		MoveObject ();
		CheckIfAtTarget ();
	}
}
