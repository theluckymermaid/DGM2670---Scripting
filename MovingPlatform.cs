using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject platforms; 

	public float moveSpeed; 

	private Transform currentPoint; 

	public Transform[] points;  //Make an array of points for our moving platform to move to. 

	public int pointSelection;

	void Start () {
		currentPoint = points [pointSelection];
	}

	void Update () {

		platforms.transform.position = Vector3.MoveTowards (platforms.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
	
		if (platforms.transform.position == currentPoint.position) 
		{
			pointSelection++;

			if (pointSelection == points.Length) 
			{
				pointSelection = 0;
			}
			currentPoint = points [pointSelection];
		}
	}
}
