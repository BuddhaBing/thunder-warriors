using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float speed = 5f;
	public float zoomspeed = 50f;

	public float maxX = -15f;
	public float minX = -25f;

	public float maxZ = -3f;
	public float minZ = -14f;

	public float maxZoom = 60f;
	public float minZoom = 20f;


	[Header("For debug and Tuning")]
	public float currentX; //these are for debugging and configuration
	public float currentZ;
	public float currentZoom = 60f;

	private float MoveDistance;
	private Vector3 moveVector;

	public void MyUpdate () {
		MoveCamera ();
		ClampToMap ();
		moveVector = new Vector3();
	}


	public void MoveUp()   {moveVector += Vector3.forward;}
	public void MoveDown() {moveVector += Vector3.back;}
	public void MoveRight(){moveVector += Vector3.right;}
	public void MoveLeft() {moveVector += Vector3.left;}

	void MoveCamera(){
		MoveDistance = speed * Time.deltaTime;
		transform.Translate (moveVector * MoveDistance, Space.World);
		Camera.main.fieldOfView = currentZoom;
	}
		
	public void Zoom (float scrollDistance)
	{
		currentZoom -= scrollDistance * zoomspeed * Time.deltaTime  ; 
	}

	void ClampToMap()
	{
		Vector3 pos = transform.position;
		currentX = pos.x; //these are for debugging and configuration
		currentZ = pos.z;
		pos.x = Mathf.Clamp (pos.x, minX, maxX);
		pos.z = Mathf.Clamp (pos.z, minZ, maxZ);
		transform.position = pos;
		currentZoom = Mathf.Clamp (currentZoom,minZoom,maxZoom);
	}
}