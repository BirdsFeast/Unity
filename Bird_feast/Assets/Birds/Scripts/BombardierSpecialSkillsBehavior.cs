using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierSpecialSkillsBehavior : MonoBehaviour {

	public GameObject bomb;
	public GameObject missile;
  public GameObject shootingPoint;
	private float bombCooldown = 0.5f;
	private float missileCooldown = 0.5f;
	private float missileCurrentCooldown = 0f;
	private float bombCurrentCooldown = 0f;
	public Transform bombShootPosition;

	/// <summary>
	/// Update Bomb's cooldown and check player's inputs
	/// </summary>
	void Update() {
    updateCooldowns();
    CheckInputs();
	}

  void updateCooldowns() {
    bombCurrentCooldown -= Time.deltaTime;
    missileCurrentCooldown -= Time.deltaTime;
    float bombPercentageCooldown = bombCurrentCooldown / bombCooldown;
    float missilePercentageCooldown = missileCurrentCooldown / missileCooldown;
    CooldownQ.fillPercentage = bombPercentageCooldown;
    CooldownW.fillPercentage = missilePercentageCooldown;
  }

  void CheckInputs() {
    if (Input.GetKeyDown (KeyCode.Q)) {
      Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
      ShootBomb (clickRay);
    }

    if (Input.GetKeyDown(KeyCode.W)) {
      Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      ShootMissile(clickRay);
    }
  }

	bool isBombInCooldown () {
		return bombCurrentCooldown > 0f;
	}

	bool isMissileInCooldown() {
		return missileCurrentCooldown > 0f;
	}
		
	/// <summary>
	/// Shoots the bomb on "click".
	/// </summary>
  /// <param name="click">Click, click to where the bomb is going to</param>
	void ShootBomb (Ray click)
  {
    if (isBombInCooldown ()) {
      return;
    }
  
    RaycastHit hit;
    Physics.Raycast (click, out hit);

    if (hit.Equals(null)) {
      return;
    }

    Vector3 shootPosition = getShootPositionToPoint(hit.point);
		GameObject newBomb = Instantiate(
			bomb,
      shootPosition,
      transform.rotation
		);  

		BombardierBombBehavior bombBehavior = newBomb.GetComponentInChildren<BombardierBombBehavior> ();
		bombBehavior.target = hit.point;
		bombCurrentCooldown = bombCooldown;
	}

  Vector3 getShootPositionToPoint(Vector3 point) {
    Vector3 direction = point - transform.position;
    return transform.position + direction.normalized * 5;
  }

  /// <summary>
  /// Shoots the missile.
  /// </summary>
  /// <param name="click">Click, click to where the missile is going to.</param>
	void ShootMissile (Ray click)
	{
		if (isMissileInCooldown ()) {
			return;
		}

		RaycastHit hit;
		if (Physics.Raycast (click, out hit))
    if(hit.Equals(null)) return;

    Vector3 shootPosition = getShootPositionToPoint(hit.point);
    GameObject newMissile = Instantiate (missile, shootPosition, bombShootPosition.rotation);
    BombardierMissileBehavior missileBehavior = newMissile.GetComponentInChildren<BombardierMissileBehavior>();
    missileBehavior.target = hit.point;
    missileCurrentCooldown = missileCooldown;
	}
}
