using UnityEngine;
using System.Collections;

public class TurretView : MonoBehaviour
{

	private TurretConfig self;

	void Awake () {
		self = GetComponent<TurretConfig>();
	}

	public void FireBullet(Transform target) {
		foreach (Transform firepoint in self.firepoints) {
			GameObject bulletGO = (GameObject)Instantiate (self.bulletPrefab, firepoint.position, firepoint.rotation);
			Bullet bullet = bulletGO.GetComponent<Bullet> ();
			if (bullet != null)
				bullet.Seek (target);
		}
	}

	public void LockOn(Vector3 rotation) {
		self.partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (self.transform.position, self.range);
	}

}

