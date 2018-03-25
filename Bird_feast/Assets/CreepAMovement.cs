using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepAMovement : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
	private int waypointsIndex = 0;

	void Start() {
		target = WaveAPath.points [0];
	}

	void Update () {
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, target.position) < 0.4f) {
			GetNextWaypoint ();
		}
	}

	void GetNextWaypoint() {
		waypointsIndex++;
		if (waypointsIndex >= WaveAPath.points.Length) return;
		target = WaveAPath.points [waypointsIndex];
	}
}
