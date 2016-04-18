using UnityEngine;
using System.Collections;

public class Movement : PowerUpBase {

	private Rigidbody2D myRigidBody;
	
	//Ground Check
	public Transform groundPoints;
	public float groundRadius;
	public LayerMask whatIsGround;
	private bool isGrounded;
	
	// Double Jump Variables
	private bool doubleJumped;

	private bool attack;
	private bool slide;
	private bool isDead;

	//Player Animation
	private Animator anim; 

	public Collider2D attackTrigger; 

	// Use this for initialization
	void Start () {

		myRigidBody = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();
		attackTrigger.enabled = false; 
	}

	void Update () {
		//PLayer Jump Animation, RunAnimation, Attack Animation
		anim.SetBool ("grounded", isGrounded);
		anim.SetFloat("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if (attack && !this.anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {

			anim.SetTrigger ("attack");
		}
	}

	void FixedUpdate () {

		isGrounded = Physics2D.OverlapCircle (groundPoints.position, groundRadius, whatIsGround);
		
		//This handles character's movement
		float horizontal = Input.GetAxis ("Horizontal");
		
		myRigidBody.velocity = new Vector2 (horizontal * playerSpeed, myRigidBody.velocity.y);
		
		if (Input.GetKey (KeyCode.LeftControl)) {

			attack = true; 
			attackTrigger.enabled = true; 
		} 
		else {

			attack = false; 
			attackTrigger.enabled = false; 
		}

		// Doesn't make the character move while attacking

		if (this.anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {

			myRigidBody.velocity = Vector2.zero;
		} else if (!this.anim.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
			myRigidBody.velocity = new Vector2 (horizontal * playerSpeed, myRigidBody.velocity.y);
		}


		//This code below makes the character jump
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, playerJump);
		}
		
		// Double Jump
		if (isGrounded)
			doubleJumped = false;

		if (Input.GetButtonDown ("Jump") && !doubleJumped && !isGrounded) {
			myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, playerJump);
			doubleJumped = true;
		}
		
		//Player flip
		if (myRigidBody.velocity.x > 0)
			transform.localScale = new Vector3 (0.4008517f, 0.4008517f, 0.4008517f);
		else if (myRigidBody.velocity.x < 0)
			transform.localScale = new Vector3 (-0.4008517f, 0.4008517f, 0.4008517f);
	}
}
