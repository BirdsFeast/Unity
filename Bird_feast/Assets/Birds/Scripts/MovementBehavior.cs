using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehavior : MonoBehaviour {

  public float distanceToTarget = Mathf.Infinity;
	private float movementSpeed = 30f;
  private Vector3 target;
  private Vector3 direction;
  private float targetRadiusLimit = 0.3f;

  public GameObject targetMarker;

	void Update() {
    CheckInputs();
    Move();
	}

  void CheckInputs() {
    if (Input.GetMouseButtonDown (1)) {
      OnRightClick();
    }
  }

  void OnRightClick () {
    SetTargetToClickPosition ();
  }

  void SetTargetToClickPosition() {
    Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(clickRay, out hit)) {
      target = hit.point;
      CreateTargetMarker();
    }
  }

  void CreateTargetMarker() {
    Quaternion defaultRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    Instantiate(targetMarker, target, defaultRotation);
    direction = transform.position - target;
  }

  void Move() {
    if(IsUnitOnTarget()) return;
    UpdateDistanceToTarget();
    float translationX = direction.normalized.x * Time.deltaTime * movementSpeed;
    float translationZ = direction.normalized.z * Time.deltaTime * movementSpeed;
    transform.Translate(-1f * translationX, 0f, -1f * translationZ, Space.World);
  }

  void UpdateDistanceToTarget () {
    distanceToTarget = Vector3.Distance(transform.position, target);
  }

  public void StopMovement() {
    target = transform.position;
  }

  bool IsUnitOnTarget () {
    Vector3 currentGroundPosition = new Vector3(transform.position.x, 0, transform.position.z);
    Vector3 targetGroundPosition = new Vector3(target.x, 0, target.z);
    bool unitCloseToTarget = Vector3.Distance(currentGroundPosition, targetGroundPosition) < targetRadiusLimit;
    return unitCloseToTarget;
  }

}