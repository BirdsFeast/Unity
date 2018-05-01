using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementBehavior : MonoBehaviour {

  public float distanceToTarget = Mathf.Infinity;
  BombardierBasicAttackBehaviour basicAttackBehaviour;
  private Vector3 target;
  NavMeshAgent agent;

  public GameObject targetMarker;

  void Start() {
    agent = GetComponent<NavMeshAgent>();
    basicAttackBehaviour = GetComponent<BombardierBasicAttackBehaviour>();
  }

	void Update() {
    CheckInputs();
    UpdateDistanceToTarget();
	}

  void CheckInputs() {
    if (Input.GetMouseButtonDown (1)) {
      OnRightClick();
    }
  }

  void OnRightClick () {
    if(basicAttackBehaviour.isAttacking) return;
    SetTargetToClickPosition ();
  }

  void SetTargetToClickPosition() {
    Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(clickRay, out hit)) {
      target = hit.point;
      CreateTargetMarkerAndMoveToDestination();
    }
  }

  void CreateTargetMarkerAndMoveToDestination() {
    Quaternion defaultRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    Instantiate(targetMarker, target, defaultRotation);
    agent.SetDestination(target);
    agent.isStopped = false;
  }

  void UpdateDistanceToTarget () {
    distanceToTarget = Vector3.Distance(transform.position, target);
  }

  public void StopMovement() {
    agent.isStopped = true;
  }
}