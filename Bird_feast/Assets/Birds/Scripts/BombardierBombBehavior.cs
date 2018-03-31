using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierBombBehavior : MonoBehaviour {

	[Header("Behavior Parameters")]

	private float timeToExplode = 2f;
	private float currentTime = 0f;
	private float speed = 1f;
	private float range = 15f;
	private int damage = 40;

	private bool hasExploded = false;

	[Header("Unity")]

	public GameObject explosion;
	public Vector3 target;

	void Awake () {
		currentTime = timeToExplode;
	}

	void Update () {
		currentTime -= Time.deltaTime;
		if (currentTime <= 0f && !hasExploded) {
			Explode ();
			hasExploded = true;
		}
		MoveToTarget ();
	}

	void MoveToTarget() {
		Vector3 direction = target - transform.position;
		transform.Translate (direction * speed * Time.deltaTime);
	}

	void Explode() {
		Instantiate (explosion, transform.position, transform.rotation);

		Collider[] colliders = Physics.OverlapSphere (transform.position, range);

		foreach (Collider nearbyObject in colliders) {
			WormHealthBehavior healthBehavior = nearbyObject.GetComponent<WormHealthBehavior> ();
			if (healthBehavior != null) {
				healthBehavior.ReduceHealth (damage);
			}
		}

		Destroy (gameObject);
	}
}
