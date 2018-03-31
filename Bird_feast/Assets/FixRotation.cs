using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation: MonoBehaviour {

	private Quaternion initialRotation;

	void Start () {
		initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = initialRotation;
	}
}
