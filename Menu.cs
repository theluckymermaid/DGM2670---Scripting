using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	//Variables. 
	public Canvas MainCanvas;
	public Canvas InstructionCanvas;

	//This function happens first before the Start function. We are disabling the Instruction Canvas. 
	void Awake () {
		InstructionCanvas.enabled = false;
	}

	//This functions returns back to the main menu from the Instruction view
	public void ReturnOn () {
		InstructionCanvas.enabled = false; 
		MainCanvas.enabled = true;
		}

	//This function goes to Instructions. Leaving the main menu. 
	public void InstructionOn () {

		InstructionCanvas.enabled = true;
		MainCanvas.enabled = false;
	}
		
	//Loads the first level
	public void LoadOn () {
		Application.LoadLevel (1);
		//SceneManager.LoadScene (1);
	}

	//Quits the game
	public void Quit () {
		Application.Quit (); //Quits the game
		}
}
