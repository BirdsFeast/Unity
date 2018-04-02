using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour {

	private float movementSpeed = 30f;
  private Vector3 target;
  private Vector3 direction;
  private float targetRadiusLimit = 3f;
  private bool debouceTargetCreation = false;

  public GameObject targetMarker;

	void Update() {
    if (Input.GetMouseButtonDown (1)) {
      OnRightClick();
    }
    Move();
	}

  void OnRightClick () {
    SetTarget ();
  }

  void SetTarget() {
    Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(clickRay, out hit)) {
      target = hit.point;
      Quaternion defaultRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
      Instantiate(targetMarker, target, defaultRotation);
      direction = transform.position - target;
      debouceTargetCreation = true;
    }
  }

  void Move() {
    if(IsUnitOnTarget()) return;
    float translationX = direction.normalized.x * Time.deltaTime * movementSpeed;
    float translationZ = direction.normalized.z * Time.deltaTime * movementSpeed;
    transform.Translate(-1f * translationX, 0f, -1f * translationZ, Space.World);
  }

  bool IsUnitOnTarget () {
    return Vector3.Distance(transform.position, target) < targetRadiusLimit;
  }

}