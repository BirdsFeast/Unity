using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierBasicAttackBehaviour : MonoBehaviour {

  public bool isAttacking = false;
 
  private GameObject target;
  private float attacksPerSecond = 1f;
  private float delayBetweenAttacks;
  private float timeUntilNextAttack = 0f;
  private int damagePerAttack = 30;
  private float range = 15f;
  private MovementBehavior movementBehavior;

  void Start() {
    movementBehavior = GetComponent<MovementBehavior>();
    delayBetweenAttacks = 1 / attacksPerSecond;
    timeUntilNextAttack = delayBetweenAttacks;
  }

  void Update ()
  {
    UpdateTimes ();
    if (ShouldPerformAttack ()) {
      PerformBasicAttack ();
    }

    if (!isAttacking && target && IsEnemy (target) && EnemyInRange()) {
      StartAttacking();
    }
    CheckInputs();
  }

  private void UpdateTimes() {
    timeUntilNextAttack -= Time.deltaTime;
  }

  private bool ShouldPerformAttack () {
    return timeUntilNextAttack <= 0f && target != null && isAttacking;
  }

  private void CheckInputs () {
    if (Input.GetMouseButtonDown (1)) {
      OnRightClick (); 
    }
  }

  private void OnRightClick () {
    if (!HitSomething ()) {
      SetAttacking (false);
      target = null;
      return;
    }

    RaycastHit hit = GetClickHit ();

    GameObject objectClicked = hit.collider.gameObject;
    if (!IsEnemy (objectClicked)) {
      SetAttacking (false);
      target = null;
      return;
    }

    target = objectClicked;

    if (EnemyInRange()) {
      StartAttacking();
    }
  }

  private bool HitSomething() {
    Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
    RaycastHit hit;
    return Physics.Raycast (clickRay, out hit);
  }

  private RaycastHit GetClickHit () {
    Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
    RaycastHit hit;
    Physics.Raycast (clickRay, out hit);
    return hit;
  }

  private bool EnemyInRange () {
    return movementBehavior.distanceToTarget < range;
  }

  private void StartAttacking () {
    movementBehavior.StopMovement();
    timeUntilNextAttack = delayBetweenAttacks;
    SetAttacking (true);
  }

  private bool IsEnemy(GameObject possibleEnemy) {
    if(possibleEnemy == null) return false;
    return possibleEnemy.CompareTag("Enemy");
  }

  private void SetAttacking(bool attacking) {
    isAttacking = attacking;
  }

  private void PerformBasicAttack() {
    timeUntilNextAttack = delayBetweenAttacks;
    BasicHealthBehavior basicHealthBehavior = target.GetComponent<BasicHealthBehavior> ();
    basicHealthBehavior.ReduceHealth(damagePerAttack);
  }
}