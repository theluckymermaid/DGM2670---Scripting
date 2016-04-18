using UnityEngine;
using System.Collections;

public class LifePickUp : MonoBehaviour {

	private LifeManager lifeSystem; 
	private Score score; 


	// Use this for initialization
	void Start () {
	
		lifeSystem = FindObjectOfType<LifeManager> (); 

		score = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<Score> ();
	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.name == "Player")
		{

			lifeSystem.AddLife(); 
			Debug.Log ("You gained a life");
		score.points += 300;
			Destroy(gameObject); 
			}
	}
}
