using UnityEngine;
using System.Collections;

public class ResetPowerUp : PowerUpBase {

	//reset the player's speed and end the speed power up. 
	public void EndPowerUpSpeed () {

		StartCoroutine ("StopSpeedPowerUp");
	}

	IEnumerator StopSpeedPowerUp ()

	{
		yield return new WaitForSeconds (5);

		playerSpeed = 4;
	}

	//Resets the player's jump and end the jump power up 

	public void EndPowerUpJump () {

		StartCoroutine ("StopJumpPowerUp");
	}

	IEnumerator StopJumpPowerUp ()

	{
		yield return new WaitForSeconds (20);

		playerJump = 5.0f;
	}
}
