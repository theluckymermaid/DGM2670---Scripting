using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// this script is for camera movement to follow the character. 

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	public GameObject player;

	public bool bounds; 

	public Vector3 minCameraPos; 
	public Vector3 maxCameraPos;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player"); //Finds knight with the tag labeled as 'player'
	}

	void FixedUpdate () {

		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX); //This is for the x position of our camera 
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY); //This is for the y position of our camera

		transform.position = new Vector3 (posX, posY, transform.position.z); //moves the camera in the x and y direction but does not move in the z direction. 
	
		//Creates a bound for the camera to not exceed 
		if (bounds)
		{
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
				Mathf.Clamp (transform.position.y, minCameraPos.y, maxCameraPos.y),
				Mathf.Clamp (transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}
}