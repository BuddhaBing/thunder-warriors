using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private PlayerSpawn playerSpawn;
	private PlayerUI playerUI;
	private PlayerInterface playerInterface;
	private CameraController playerCamera;

	void Start () {
		var playerConfig = GetComponentInParent<PlayerConfig> ();
		playerSpawn = playerConfig.spawn;
		playerUI = playerConfig.UI;
		playerInterface = playerConfig.playerInterface;
		playerCamera = playerConfig.cameraController;
	}

	void Update () {
		playerUI.MyUpdate();
		playerSpawn.MyUpdate(Time.deltaTime);
		playerInterface.MyUpdate ();
		playerCamera.MyUpdate ();
	}
}
