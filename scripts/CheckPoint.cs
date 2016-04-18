using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	
	public enum States { 
		Inactive, 
		Active, 
		Locked
	};

	public States status;

	public Sprite [ ] sprites ; 

	public CheckPointHandler checkPointHandler;

	public GameManager gameManager; 

	public delegate void HandleCheckPoint (GameObject currentCheckPoint );

	public static event HandleCheckPoint handleCheckPoint; 

	public void Start () {
	
		checkPointHandler = GameObject.FindGameObjectWithTag ("CheckPointHandler").GetComponent<CheckPointHandler> ();
		}

	public void Update ( )
	{
		CheckPointSprites ();
	}

	public void CheckPointSprites ( ) {

		switch (status) {

		case States.Inactive:
			GetComponent <SpriteRenderer> ().sprite = sprites [0];
			break;
		case States.Active :
				GetComponent<SpriteRenderer>().sprite=sprites [1];
				break;
		case States.Locked :
			GetComponent <SpriteRenderer>().sprite=sprites [2];
			break; 
		default:
			break;
		}
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			if (handleCheckPoint != null){
				handleCheckPoint (this.gameObject); 
			}
			gameManager.currentCheckPoint = gameObject;
		}
	}
}
