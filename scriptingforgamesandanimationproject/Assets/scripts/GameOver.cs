using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverUI;
	
	public bool gameover = false;

	
	
	void Start (){
		
		gameOverUI.SetActive (false);
	}
	
	void Update (){

	}
	
	//Quits the game
	public void Quit () {
		
		Application.Quit (); //Quits the game
		
	}

	//Restarts the level function
	public void Restart () {
		
		Application.LoadLevel (Application.loadedLevel); // the application should reload the current level that you are on
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	//Returns to the main menu
	public void MainMenu (){
		
		Application.LoadLevel (0); //Should load the scene that has an index of 1
		//SceneManager.LoadScene (0);
	}

	public void EndGame () {

		gameOverUI.SetActive(true);		
  }
}
