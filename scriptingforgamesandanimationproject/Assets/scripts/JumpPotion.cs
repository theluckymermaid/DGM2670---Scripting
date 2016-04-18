using UnityEngine;
using System.Collections;

public class JumpPotion : PowerUpBase {

	public float JumpBoost = 0.5f;
	private Score score;
	
	public ResetPowerUp resetPowerUp;

	void Start ( ) {

		resetPowerUp = FindObjectOfType <ResetPowerUp> ();
		score = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<Score> ();

	}

	void OnTriggerEnter2D (Collider2D col) 
	{

		if (col.CompareTag ("Player")) 
			potions (JumpBoost);
		score.points += 200;
		print (PowerUpBase.playerJump);
		Destroy (gameObject);
		resetPowerUp.EndPowerUpJump();
	}
}
