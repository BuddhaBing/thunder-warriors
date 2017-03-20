using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float speed = 5f;
	public float zoomspeed = 50f;
	public float border = 30f;

	public float maxX = -15f;
	public float minX = -25f;

	public float maxZ = -3f;
	public float minZ = -14f;

	public float maxZoom = 60f;
	public float minZoom = 20f;

	public float currentX; //these are for debugging and configuration
	public float currentZ;
	public float currentZoom = 60f;



	private float MoveDistance;
	private Vector3 moveVector;

	void Update () {
		MoveCamera ();
		ClampToMap ();
		Zoom ();
	}
	void MoveCamera(){

		moveVector = new Vector3();
		MoveDistance = speed * Time.deltaTime;
		if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height - border) {
			moveVector += Vector3.forward;
		}
		if (Input.GetKey ("s") || Input.mousePosition.y <= border) {
			moveVector += Vector3.back;
		}
		if (Input.GetKey ("a") || Input.mousePosition.x <= border) {
			moveVector += Vector3.left;
		}
		if (Input.GetKey ("d") || Input.mousePosition.x  >= Screen.width - border) {
			moveVector += Vector3.right;
		}
		transform.Translate (moveVector * MoveDistance, Space.World);
	}

	void Zoom ()
	{
		currentZoom -= Input.GetAxis("Mouse ScrollWheel")* zoomspeed * Time.deltaTime  ; 
		currentZoom = Mathf.Clamp (currentZoom,minZoom,maxZoom);
		Camera.main.fieldOfView = currentZoom;
	
	}

	void ClampToMap()
	{
		Vector3 pos = transform.position;
		currentX = pos.x; //these are for debugging and configuration
		currentZ = pos.z;
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.z = Mathf.Clamp (pos.z, minZ, maxZ);
		transform.position = pos;
	}
}