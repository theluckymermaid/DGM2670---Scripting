using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	private Movement player; 
	private HealthManager health; 
	
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath;

	public LifeManager lifeSystem;
	
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Movement> ();
		health = FindObjectOfType<HealthManager> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer (){
		StartCoroutine ("RespawnPlayerCo");
	}


	public void NoRespawn () {

		StopCoroutine ("RespawnPlayerCo"); 
	}
	public IEnumerator RespawnPlayerCo() {
		//generate death particles
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		
		//hiades player
		player.enabled = false;
		player.GetComponent<Renderer> ().enabled = false;
		
		//respawn delay

		yield return new WaitForSeconds (respawnDelay);

		//match players transform position
		player.transform.position = currentCheckPoint.transform.position;
		
		//show player 
		player.enabled = true;
		player.GetComponent<Renderer> ().enabled = true;
		
		//players health is set back to max
		health.currentHealth = health.maxHealth; 
		
		//spawn player 
		Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}

}
