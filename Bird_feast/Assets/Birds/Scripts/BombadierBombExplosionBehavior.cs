using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombadierBombExplosionBehavior : MonoBehaviour {

	private float timeToLive = 0.5f;
	private float currentTime = 0f;

	void Start() {
		currentTime = timeToLive;
	}

	void Update() {
		currentTime -= Time.deltaTime;
		if (currentTime <= 0f) {
			Destroy (gameObject);
		}
	}
}
