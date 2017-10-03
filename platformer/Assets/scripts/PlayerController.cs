﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; 
	//public Rigidbody rb; 
	public float jumpForce; 

	public CharacterController controller; 

	private Vector3 moveDirection; 
	public float gravityScale; 

	public Animator anim; 

	public Transform pivot; 
	public float rotatePivot; 

	public GameObject playerModel; 

	public float knockBackForce; 
	public float knockBackTime; 
	private float knockBackCounter; 

	// Use this for initialization
	void Start () {
	//	rb = GetComponent<Rigidbody> (); 
		controller = GetComponent<CharacterController>(); 

	}
	
	// Update is called once per frame
	void Update () {
		/*
		rb.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,rb.velocity.y,Input.GetAxis("Vertical")*moveSpeed);

		if(Input.GetButtonDown("Jump")){
			rb.velocity = new Vector3 (rb.velocity.x, jumpForce, rb.velocity.z);

		}
		*/


		//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis ("Vertical") * moveSpeed);
		if (knockBackCounter <= 0) {
			float yStore = moveDirection.y;
			moveDirection = (transform.forward * Input.GetAxisRaw ("Vertical")) + (transform.right * Input.GetAxisRaw ("Horizontal"));
			moveDirection = moveDirection.normalized * moveSpeed; //aplico la gravedad de vuelta porque lo normalice y anda lento
			moveDirection.y = yStore; 


			if (controller.isGrounded) {
				//moveDirection = new Vector3 (Input.GetAxis ("Horizontal") * moveSpeed, 0f, Input.GetAxis ("Vertical") * moveSpeed); esto lo que hace es que no se pueda mover en el aire
				moveDirection.y = 0f; 
				if (Input.GetButtonDown ("Jump")) {
					moveDirection.y = jumpForce;

				}
			}

		} else {
			knockBackCounter -= Time.deltaTime; 

		}
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale*Time.deltaTime);

		controller.Move (moveDirection * Time.deltaTime);

		//Move the player in different directions based on camera look direction
		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			transform.rotation = Quaternion.Euler (0f, pivot.rotation.eulerAngles.y, 0f);
			Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x,0f,moveDirection.z));
			playerModel.transform.rotation = Quaternion.Slerp (playerModel.transform.rotation, newRotation, rotatePivot * Time.deltaTime);

		}

		anim.SetBool ("isGrounded", controller.isGrounded);
		anim.SetFloat ("Speed", (Mathf.Abs (Input.GetAxis ("Vertical"))+Mathf.Abs(Input.GetAxis("Horizontal"))));
		
	}


	public void KnockBack(Vector3 direction)
	{
		knockBackCounter = knockBackTime;


		moveDirection = direction * knockBackForce;
		moveDirection.y = knockBackForce; 


	}
}
