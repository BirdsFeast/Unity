using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMarker : MonoBehaviour {

  private float lifetime = 3f;
  private float currentLifetime = 0f;


  void Start() {
    currentLifetime = lifetime;
  }

	void Update ()
  {
    currentLifetime -= Time.deltaTime;
    if (currentLifetime <= 0f) {
      Destroy(gameObject);
    }
	}
}
