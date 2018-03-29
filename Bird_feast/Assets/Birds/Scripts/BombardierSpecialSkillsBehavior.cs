using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombardierSpecialSkillsBehavior : MonoBehaviour {

	public GameObject bomb;
	private float bombCooldown = 3f;
	private float bombCurrentCooldown = 0f;
	public Transform bombShootPosition;
	private float range = 10f;
	public GameObject enemy;

	/// <summary>
	/// Update Bomb's cooldown and check player's inputs
	/// </summary>
	void Update() {
		bombCurrentCooldown -= Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Q)) {
			Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			ShootBomb (clickRay);
		}

	}

	/// <summary>
	/// Is the bomb in cooldown.
	/// </summary>
	bool isBombInCooldown () {
		return bombCurrentCooldown > 0f;
	}
		
	/// <summary>
	/// Shoots the bomb.
	/// </summary>
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
		Debug.Log ("Click direction x" + click.direction.x.ToString());
		Debug.Log ("Click direction y" + click.direction.y.ToString());
		if (Physics.Raycast(click, out hit)) {
			BombardierBombBehavior bombBehavior = newBomb.GetComponentInChildren<BombardierBombBehavior> ();
			Debug.Log ("Position x" + hit.point.x.ToString());
			Debug.Log ("Position y" + hit.point.y.ToString());
			bombBehavior.target = hit.point;
			bombCurrentCooldown = bombCooldown;	
		}
	}

}
