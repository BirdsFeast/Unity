using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierBombBehavior : MonoBehaviour {

	[Header("Behavior Parameters")]

	private float timeToExplode = 2f;
	private float currentTime = 0f;
	private float speed = 10f;
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
    float translationX = direction.normalized.x * speed * Time.deltaTime;
    float translationZ = direction.normalized.z * speed * Time.deltaTime;
		transform.Translate (translationX, 0, translationZ, Space.World);
	}

	void Explode() {
		Instantiate (explosion, transform.position, transform.rotation);

		Collider[] colliders = Physics.OverlapSphere (transform.position, range);

		foreach (Collider nearbyObject in colliders) {
			BasicHealthBehavior healthBehavior = nearbyObject.GetComponent<BasicHealthBehavior> ();
			if (healthBehavior != null) {
				healthBehavior.ReduceHealth (damage);
			}
		}

		Destroy (gameObject);
	}
}
