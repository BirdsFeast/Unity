using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	[Header("Attributes")]
	public static int wormsScore = 0;
	public static int birdsScore = 0;

	[Header("Unity Setup Fields")]
	public Text wormsText;
	public Text birdsText;

	void Update() {
		UpdateUI ();
	}

	void UpdateUI() {
		wormsText.text = "Worms: " + wormsScore.ToString();
		birdsText.text = "Birds: " + birdsScore.ToString();
	}
}
