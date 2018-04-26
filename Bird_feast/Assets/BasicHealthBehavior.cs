using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicHealthBehavior : MonoBehaviour {

	public int totalHealth = 100;
	private int currentHealth;

	public Image healthBar;

	void Start() {
		currentHealth = totalHealth;
	}


	public void ReduceHealth(int damage) {
		currentHealth -= damage;
		healthBar.fillAmount = currentHealth * 1.0f / totalHealth;
		if (currentHealth <= 0) {
			ScoreKeeper.birdsScore++;
			Destroy (gameObject);
		}
	}
}
