using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	public bool paused = false;


	void Start (){

		PauseUI.SetActive (false);
	}

	void Update (){

		//Toggles the Pause button
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) {
			PauseUI.SetActive(true);
			Time.timeScale = 0; 
		}

		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1; 
		}
	}

	//Quits the game
	public void Quit () {

		Application.Quit (); //Quits the game
	}

	//Resumes the game
	public void Resume (){

		paused = false;
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


		

}
