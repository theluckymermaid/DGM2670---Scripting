using UnityEngine;
using System.Collections;

public class PowerUpBase : MonoBehaviour {

	public static int playerSpeed = 4;
	public static float playerJump = 5f;

	public void potions (int speed)
	{
		playerSpeed += speed;
	}

	public void potions (float jump)
	{
		playerJump += jump;
	}
}
