using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public Transform startPoint;
	public int waveIndex = 0;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	void Update() {
		countdown -= Time.deltaTime;
		if (countdown <= 0f) {
			StartCoroutine(SpawnWave ());
			countdown = timeBetweenWaves;	
		}
	}

	IEnumerator SpawnWave() {
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
		waveIndex++;
	}

	void SpawnEnemy() {
		Instantiate (enemyPrefab, startPoint.position, startPoint.rotation);
	}
	
}
