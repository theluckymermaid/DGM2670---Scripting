using UnityEngine;
using System.Collections;

public class Potions : PowerUpBase {

	public int speedBoost = 5;
	public ResetPowerUp resetPowerUp;

	void Start ( ) {

		resetPowerUp = FindObjectOfType <ResetPowerUp> ();
	}

	void OnTriggerEnter2D (Collider2D col) 
	{
			if (col.CompareTag ("Player")) 
			potions (speedBoost);
			print (PowerUpBase.playerSpeed);
		    Destroy (gameObject);

		resetPowerUp.EndPowerUpSpeed();
	}
}
