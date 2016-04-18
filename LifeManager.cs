using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	public int startingLives; 
	private int lifeCounter;
	public GameObject deathParticle;

	private Text life; 

	public Movement player;
	public GameManager gameManager;
	public GameObject gameOverUI; 
 
	void Start () {

		life = GetComponent<Text> (); 

		lifeCounter = startingLives; 

		player = FindObjectOfType<Movement> (); 
	}

	void Update () {

		if (lifeCounter == 0) {

			GameOver (); 
			gameOverUI.SetActive (true); 
			player.gameObject.SetActive (false); 
		}
		life.text = "x " + lifeCounter;
	}

	public void AddLife() {

		lifeCounter++;
	}

	public void TakeLife () {
		lifeCounter--; 

	}

	IEnumerator GameOverCo () { 
		
		gameManager.NoRespawn (); 
		yield return new WaitForSeconds (1); 

		player.transform.position = currentCheckPoint.transform.position;
		StopGameOver (); 
	}

	public void GameOver () {

		StartCoroutine ("GameOverCo"); 
	}

	public void StopGameOver() {

		StopCoroutine ("GameOverCo"); 
	}

		
}
