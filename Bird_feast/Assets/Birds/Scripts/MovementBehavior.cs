using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour {

	private float speed = 20f;

	void Update() {
		float moveHorizontal = GetMovementHorizontal ();
		float moveVertical = GetMovementVertical ();
		transform.Translate (moveHorizontal, 0f, moveVertical, Space.World);
	}

	float GetMovementHorizontal () {
		if (Input.GetAxis ("Horizontal") > 0f) {
			return Time.deltaTime* speed;
		}
		if (Input.GetAxis ("Horizontal") < 0f) {
			return -1 * Time.deltaTime * speed;
		}
		return 0f;
	}

	float GetMovementVertical() {
		if (Input.GetAxis ("Vertical") > 0f) {
			return Time.deltaTime* speed;
		}
		if (Input.GetAxis ("Vertical") < 0f) {
			return -1 * Time.deltaTime * speed;
		}
		return 0f;
	}
}
