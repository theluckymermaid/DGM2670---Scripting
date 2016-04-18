using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckPointHandler : MonoBehaviour {

	public List <GameObject > checkPointTrigger;
	 
	public GameObject[] checkpoints; 

	public int checkPointCounter; 

	// Use this for initialization
	void Start () {

		checkpoints = GameObject.FindGameObjectsWithTag ("checkpoints");
		List <GameObject> checkPointTrigger = new List <GameObject>();
		checkPointCounter = 1;
		OnEnabled (); 
	}

	void OnEnabled () {
		CheckPoint.handleCheckPoint += UpdateCheckPoints;
	}

	public void UpdateCheckPoints (GameObject currentCheckPoint ) {
		//This is saying if the current check point is not lock, the previous checkpoint should have the status of locked and the boxcollider is disabled so you don't respawn at that checkpoint if cross it again. 

		 if (currentCheckPoint.GetComponent<CheckPoint> ().status != CheckPoint.States.Locked) {

			foreach (GameObject checkpoint in checkpoints) {

				if (checkpoint != currentCheckPoint && checkpoint.GetComponent<CheckPoint> ().status != CheckPoint.States.Inactive) {

					checkpoint.GetComponent<CheckPoint> ().status = CheckPoint.States.Locked; 
					BoxCollider2D checkpointBox =  checkPointTrigger[checkPointCounter - 1].GetComponent<BoxCollider2D>();
					checkpointBox.enabled = false;
					checkPointCounter ++; 
					}
				}
				currentCheckPoint.GetComponent<CheckPoint> ().status = CheckPoint.States.Active; 
			}
		}
	}

