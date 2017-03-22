using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterface : MonoBehaviour {

	private BuildingManager buildingManager;
	private CameraController cameraController;

	public float DistanceFromEdgeBeforeScroll = 30f;

	void Start () {
		var playerConfig = GetComponentInParent<PlayerConfig> ();
		buildingManager = playerConfig.buildingManager;
		cameraController = playerConfig.cameraController;
	}

	public void MyUpdate () {
		CameraControls ();		
		TurretBuildSection ();
	}

	private void CameraControls(){
		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - DistanceFromEdgeBeforeScroll) {
			cameraController.MoveUp ();
		}
		if (Input.GetKey ("s") || Input.mousePosition.y <= DistanceFromEdgeBeforeScroll) {
			cameraController.MoveDown ();
		}
		if (Input.GetKey ("a") || Input.mousePosition.x <= DistanceFromEdgeBeforeScroll) {
			cameraController.MoveLeft ();
		}
		if (Input.GetKey ("d") || Input.mousePosition.x  >= Screen.width - DistanceFromEdgeBeforeScroll) {
			cameraController.MoveRight ();
		}
		cameraController.Zoom (Input.GetAxis ("Mouse ScrollWheel"));
	}

	private void TurretBuildSection(){
		if(Input.GetMouseButtonDown(0) && !(Input.GetKey("left shift") || Input.GetKey("right shift")))
			buildingManager.SetTurretToBuild (null);
		if(Input.GetKeyUp ("left shift") || Input.GetKeyUp ("right shift"))
			buildingManager.SetTurretToBuild (null);	
	}
}
