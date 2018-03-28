using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour {

	private float speed = 100f;

	void Update() {
		float moveHorizontal = GetMovementHorizontal ();
		float moveVertical = GetMovementVertical ();
		transform.Translate (moveHorizontal, 0f, moveVertical, Space.World);
	}

	float GetMovementHorizontal () {
		Debug.Log (speed);
		return Input.GetAxis ("Horizontal") * Time.deltaTime * speed;
	}

	float GetMovementVertical() {
		return Input.GetAxis ("Vertical") * Time.deltaTime * speed;
	}
}
