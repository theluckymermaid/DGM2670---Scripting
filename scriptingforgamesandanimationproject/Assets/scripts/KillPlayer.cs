using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public GameManager player; 
	
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other){
		
		if(other.name == "Player")
		{
			
			Debug.Log("Player was killed by Enemy");
			player.RespawnPlayer (); 
		}
		
	}
}