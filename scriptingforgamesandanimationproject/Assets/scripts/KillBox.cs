using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	public GameManager player; 
	public LifeManager life;  

	void Start () {

		life = FindObjectOfType<LifeManager> (); 
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if(other.name == "Player")
		{
			life.TakeLife();
			//health.Damage (100);  
			Debug.Log("Player Enters Death Zone");
			player.RespawnPlayer ();
		}
		
	}
}
