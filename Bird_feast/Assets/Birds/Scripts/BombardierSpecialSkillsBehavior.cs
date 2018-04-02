using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierSpecialSkillsBehavior : MonoBehaviour {

	public GameObject bomb;
	public GameObject missile;
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
    checkInputs();
	}

  /// <summary>
  /// Checks which inputs are pressed.
  /// </summary>
  void checkInputs() {
    if (Input.GetKeyDown (KeyCode.Q)) {
      Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
      ShootBomb (clickRay);
    }

    if (Input.GetKeyDown(KeyCode.W)) {
      Ray clickRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      ShootMissile(clickRay);
    }
  }

  /// <summary>
  /// Updates the cooldowns.
  /// </summary>
  void updateCooldowns() {
    bombCurrentCooldown -= Time.deltaTime;
    missileCurrentCooldown -= Time.deltaTime;
    float bombPercentageCooldown = bombCurrentCooldown / bombCooldown;
    float missilePercentageCooldown = missileCurrentCooldown / missileCooldown;
    CooldownQ.fillPercentage = bombPercentageCooldown;
    CooldownW.fillPercentage = missilePercentageCooldown;
  }

	/// <summary>
	/// Is the bomb in cooldown.
	/// </summary>
	bool isBombInCooldown () {
		return bombCurrentCooldown > 0f;
	}

	bool isMissileInCooldown() {
		return missileCurrentCooldown > 0f;
	}
		
	/// <summary>
	/// Shoots the bomb.
	/// </summary>
  /// <param name="click">Click, click to where the bomb is going to</param>
	void ShootBomb(Ray click) {
		if (isBombInCooldown()) {
			return;
		}

		GameObject newBomb = Instantiate(
			bomb,
			bombShootPosition.position,
			bombShootPosition.rotation
		);

		RaycastHit hit;

		if (Physics.Raycast(click, out hit)) {
			BombardierBombBehavior bombBehavior = newBomb.GetComponentInChildren<BombardierBombBehavior> ();
			bombBehavior.target = hit.point;
			bombCurrentCooldown = bombCooldown;
		}
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

		GameObject newMissile = Instantiate (missile, bombShootPosition.position, bombShootPosition.rotation);
		RaycastHit hit;

		if (Physics.Raycast (click, out hit)) {
			BombardierMissileBehavior missileBehavior = newMissile.GetComponentInChildren<BombardierMissileBehavior>();
      missileBehavior.target = hit.point;
      missileCurrentCooldown = missileCooldown;
		}
	}
}
