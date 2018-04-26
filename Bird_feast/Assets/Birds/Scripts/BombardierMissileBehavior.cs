using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierMissileBehavior : MonoBehaviour {

  public Vector3 target;
  private float speed = 3f;
  private float missileBodyRadius = 2f;
  private int damage = 40;
  private Vector3 direction;

  public GameObject explosion;

  void Start() {
    direction = target - transform.position;
  }

  void Update() {
    Move();
    CheckColliders();
  }

  void Move() {
    float translationX = direction.x * Time.deltaTime * speed;
    float translationZ = direction.z * Time.deltaTime * speed;
    transform.Translate(translationX, 0 ,translationZ, Space.World);
  }

  void CheckColliders ()
  {
    Collider[] colliders = Physics.OverlapSphere (transform.position, missileBodyRadius);

    foreach (Collider nearbyObject in colliders) {
      DamageEnemy(nearbyObject);
      DestroyCheck(nearbyObject);
    }
  }

  void DamageEnemy (Collider enemy) {
    if (enemy.gameObject.CompareTag("Enemy")) {
      BasicHealthBehavior basicHealthBehavior = enemy.GetComponent<BasicHealthBehavior> ();
        if (basicHealthBehavior != null) {
          basicHealthBehavior.ReduceHealth(damage);
        }
      }
  }

  void DestroyCheck(Collider collider) {
    if (collider.gameObject.CompareTag ("EnvironmentCollider") || collider.CompareTag("Enemy")) {
      Destroy (gameObject);
    }
  }

  void Explode () {
    Instantiate (explosion, transform.position, transform.rotation);
  }

}
