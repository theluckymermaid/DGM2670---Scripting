using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {


	//Enemy's Movement
	public float enemySpeed;
	public bool moveRight;

	//Wall Check
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	//Edge Check

	private bool notAtEdge;
	public Transform edgeCheck;
	public LayerMask whatIsGround;

	public int currentHealth;
	public int maxHealth = 20;

	//Enemy particles and points
	public GameObject enemyDeathParticle;  
	public int pointsforKill; 

	//Accessing scripts 
	private Score score;
	private EnemyScript enemy; 

	//Animation

	void Start ()
	{
		currentHealth = maxHealth;
		score = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<Score> ();
		enemy = FindObjectOfType<EnemyScript> ();
	}


	void Update ()
	{

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsGround);
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall || !notAtEdge) {
			moveRight = !moveRight;
		}
		if (moveRight) {
			transform.localScale = new Vector3 (- 1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-enemySpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (enemySpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}


		//Health

		if (currentHealth >= maxHealth) 
		{
			currentHealth = maxHealth;
		}
		//If enemey's health reaches 0, character will die and go to current checkpoint
		if (currentHealth <= 0) 
		{
			Die();
		}
	}

	public void Damage (int damage)
	{
		currentHealth -= damage;
	}

	public void Die () 
	{
		Instantiate (enemyDeathParticle, enemy.transform.position, enemy.transform.rotation);
		Destroy (gameObject);
		score.points += 100;
	}


}