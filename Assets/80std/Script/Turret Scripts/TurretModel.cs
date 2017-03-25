using UnityEngine;
using System.Collections;

public class TurretModel : MonoBehaviour
{

	private TurretConfig self;

	private float fireCountdown = 0f;
	private float fireRate = 0f;

	void Start () {
		self = GetComponent<TurretConfig>();
		fireRate = self.fireRate;
	}

	public void SetOwner(PlayerConfig player) {
		self.owner = player;
	}

	public PlayerConfig Owner() {
		return self.owner;
	}

	public bool IsTimeToFire() {
		return fireCountdown <= 0f;
	}

	public void DecreaseTimer() {
		fireCountdown -= Time.deltaTime;
	}

	public void ResetTimer(float fireRate) {
		fireCountdown = 1f / fireRate;
	}

}

