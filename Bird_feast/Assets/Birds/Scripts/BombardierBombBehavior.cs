using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierBombBehavior : MonoBehaviour {

	[Header("Behavior Parameters")]

	private float timeToExplode = 5f;
	private float currentTime = 0f;
	private float speed = 1f;

	[Header("Unity")]

	public GameObject explosion;
	public Vector3 target;

	void Awake () {
		currentTime = timeToExplode;
	}

	void Update () {
		currentTime -= Time.deltaTime;
		if (currentTime <= 0f) {
			Explode ();
		}
		MoveToTarget ();
	}

	void MoveToTarget() {
		Vector3 direction = target - transform.position;
		transform.Translate (direction * speed * Time.deltaTime);
	}

	void Explode() {
		Instantiate (explosion);
		Destroy (gameObject);
	}
}
