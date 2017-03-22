using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerConfig: MonoBehaviour {
	public EnemyManager enemyManager;
	public PlayerMoney money;
	public PlayerHealth health;
	public PlayerScore score;
	public PlayerUI UI;
	public PlayerSpawn spawn;
	public PlayerInterface playerInterface;
	public PlayerState state;
	public BuildingManager buildingManager;
	public CameraController cameraController;
}
