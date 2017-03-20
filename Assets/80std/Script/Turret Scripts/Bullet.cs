using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;
	public int damage = 50;
	public GameObject impactEffect;

	public void Seek (Transform _target) {
		target = _target;
	}

	void Update () {
		if(target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {
			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
	}

	void HitTarget () {
		GameObject effectIns = Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (effectIns, 2f); //destroys effect
		target.GetComponent<EnemyHealth> ().TakeDamage (damage); //deals damage
		Destroy (gameObject); //destroys bullet
	}
}
