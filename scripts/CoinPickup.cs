using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	private Score score;

	void Start () {

		score = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<Score> ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.CompareTag ("Player")) 
		{
			Destroy (gameObject);
			score.points += 100;
		}
	}
}
