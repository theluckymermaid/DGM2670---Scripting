using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int points;

	public Text scoreText; 
	
	// Update is called once per frame
	void Update () {
	
		scoreText.text = ("Score: " + points); 

	}
}
