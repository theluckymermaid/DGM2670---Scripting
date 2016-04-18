using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {


	public int currentHealth; 
	public int maxHealth  = 100; 
	public LifeManager lifeSystem;

	// Use this for initialization
	void Start () {

		currentHealth = maxHealth; 
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentHealth >= maxHealth) {

			currentHealth = maxHealth; 
		}

		if (currentHealth <= 0)
			lifeSystem.TakeLife (); 


	
	}

	public void Damage (int damage) {

		currentHealth -= damage; 
	}

}
